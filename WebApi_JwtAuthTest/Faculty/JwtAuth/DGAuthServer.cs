

using JwtAuth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelsDB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace DGAuthServer;

/// <summary>
/// DgJwtAuth에서 토큰 처리를 위한 유틸 인터페이스
/// </summary>
public interface DGAuthServerInterface
{
    /// <summary>
    /// 엑세스 토큰 생성
    /// </summary>
    /// <param name="idUser">유저 구분을 위한 고유 번호</param>
    /// <returns></returns>
    public string AccessTokenGenerate(long idUser);

    /// <summary>
    /// 엑세스 토큰 확인.
    /// <para> </para>
    /// </summary>
    /// <remarks>미들웨어에서도 호출해서 사용한다.</remarks>
    /// <param name="token"></param>
    /// <returns>찾아낸 idUser, 토큰 자체가 없으면 -1, 토큰이 유효하지 않으면 0 </returns>
    public int AccessTokenValidate(string token);

    /// <summary>
    /// 리플레시 토큰 생성.
    /// </summary>
    /// <remarks>중복검사는 하지 않으므로 필요하다면 호출한쪽에서 중복검사를 해야 한다.</remarks>
    /// <returns></returns>
    public string RefreshTokenGenerate();

    /// <summary>
    /// HttpContext.User의 클레임을 검색하여 유저 고유정보를 받는다.
    /// </summary>
    /// <param name="claimsPrincipal"></param>
    /// <returns></returns>
    public long? ClaimDataGet(ClaimsPrincipal claimsPrincipal);
}

/// <summary>
/// DgJwtAuth에서 토큰 처리
/// </summary>
public class DGAuthServer : DGAuthServerInterface
{
    /// <summary>
    /// 설정된 세팅 정보
    /// </summary>
    private readonly DgJwtAuthSettingModel _JwtAuthSetting;

    /// <summary>
    /// 
    /// </summary>
    private readonly Func<DisposableScopedContextWrapper> _func;

    public DGAuthServer(
        IOptions<DgJwtAuthSettingModel> appSettings
        //, DgJwtAuthDbContext context
        , Func<DisposableScopedContextWrapper> func)
    {
        _JwtAuthSetting = appSettings.Value;
        //_DBContext = context;
        _func = func;

        using (DgJwtAuthDbContext wrapper = _func().Context)
        {
            wrapper.DgJwtAuthAccessToken
                .Add(new DgJwtAuthAccessToken()
                {
                    idUser = 1,
                    Secret = "asdfasdfasdfasdffdffdf"
                });

            wrapper.SaveChanges();
        }

        if (_JwtAuthSetting.Secret == null 
            || _JwtAuthSetting.Secret == string.Empty)
        {//시크릿 값이 없다.

            //새로 생성한다.
            _JwtAuthSetting.Secret 
                = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }


    
    public string AccessTokenGenerate(long idUser)
    {

        //시크릿 키 임시 저장
        string sSecret = string.Empty;
        
        if (true == this._JwtAuthSetting.SecretAlone)
        {//혼자사용하는 시크릿

            DgJwtAuthAccessToken? findAT = null;

            using (DgJwtAuthDbContext db1 = _func().Context)
            {
                findAT 
                    = db1.DgJwtAuthAccessToken
                        .Where(w => w.idUser == idUser)
                        .FirstOrDefault();

                if (null != findAT)
                {//사용하는 시크릿이 있다.

                    //전달
                    sSecret = findAT.Secret;
                }
                else
                {//사용하는 시크릿이 없다.
                    DgJwtAuthAccessToken newAT = new DgJwtAuthAccessToken();
                    //사용자 입력
                    newAT.idUser = idUser;
                    //새로운 시크릿을 생성한다.
                    sSecret = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                    newAT.Secret = sSecret;

                    //db에 적용
                    db1.Add(newAT);
                    db1.SaveChanges();
                }
            }//end using db1
        }
        else
        {
            //공용 시크릿을 쓴다.
            sSecret = this._JwtAuthSetting.Secret!;
        }

        //시크릿을 바이트 배열로 변환
        byte[] byteSecretKey = new byte[0];
        byteSecretKey = Encoding.ASCII.GetBytes(sSecret);


        //jwt 보안 토큰 핸들러
        JwtSecurityTokenHandler tokenHandler 
            = new JwtSecurityTokenHandler();

        //엑세스키 생성에 필요한 정보를 입력한다.
        SecurityTokenDescriptor tokenDescriptor 
            = new SecurityTokenDescriptor
            {
                //추가로 담을 정보(클래임)
                Subject = new ClaimsIdentity(new[] { new Claim("idUser", idUser.ToString()) }),
                //유효기간
                Expires = DateTime.UtcNow.AddSeconds(this._JwtAuthSetting.AccessTokenLifetime),
                //암호화 방식
                SigningCredentials 
                    = new SigningCredentials(new SymmetricSecurityKey(byteSecretKey)
                                                , SecurityAlgorithms.HmacSha256Signature)
            };

        //토큰 생성
        SecurityToken token 
            = tokenHandler.CreateToken(tokenDescriptor);

        //직렬화
        StringBuilder sbToken = new StringBuilder();
        if (true == this._JwtAuthSetting.SecretAlone)
        {//혼 자사용하는 시크릿

            //맨앞에 유저 고유번호를 붙여준다.
            sbToken.Append(idUser);
            //구분 기호
            sbToken.Append(this._JwtAuthSetting.SecretAloneDelimeter);
        }

        //만들어진 토큰 추가
        sbToken.Append(tokenHandler.WriteToken(token));

        return sbToken.ToString();
    }

    public int AccessTokenValidate(string sToken)
    {


        if (string.IsNullOrEmpty(sToken))
        {//전달된 토큰 값이 없다.
            return -1;
        }


        //토큰
        string sTokenCut = string.Empty;
        //찾아낸 유저 번호
        long idUser = 0;
        //시크릿 키 임시 저장
        string sSecret = string.Empty;

        //혼
        if (true == this._JwtAuthSetting.SecretAlone)
		{//혼자사용하는 시크릿

			//이경우 앞에 유저번호를 먼저 분리한다.
			string[] arrCutToke = sToken.Split(this._JwtAuthSetting.SecretAloneDelimeter);

			if (2 > arrCutToke.Length)
			{//엑세스 토큰에 유저 번호가 없다.
				return 0;
			}

			if (false == Int64.TryParse(arrCutToke[0], out idUser))
			{//숫자로 변환할 수 없다.
				return 0;
			}
			else if (0 == idUser)
			{//유저 정보가 잘못 되었다.
				return 0;
			}

            //잘린 데이터 저장
			sTokenCut = arrCutToke[1];

            //
            DgJwtAuthAccessToken? findAT = null;

            //연결된 시크릿 검색
            using (DgJwtAuthDbContext db1 = _func().Context)
            {
                findAT
                    = db1.DgJwtAuthAccessToken
                        .Where(w => w.idUser == idUser)
                        .FirstOrDefault();

            }//end using db1

            if (null == findAT
                || string.Empty == findAT.Secret)
            {//시크릿 정보가 없다.
                return 0;
            }

            //찾은 시크릿 전달
            sSecret = findAT.Secret;
        }
		else
		{
			sTokenCut = sToken;
            sSecret = this._JwtAuthSetting.Secret!;

        }



		JwtSecurityTokenHandler tokenHandler 
            = new JwtSecurityTokenHandler();
        byte[] byteKey 
            = Encoding.ASCII.GetBytes(sSecret);
        try
        {
            tokenHandler.ValidateToken(sToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(byteKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "idUser").Value);

            //찾은 아이디
            return accountId;
        }
        catch
        {//토큰을 해석하지 못했다.
            
            //토큰을 어떤사유에서든 해석하지 못하면 0 에러를 내보내어
            //상황에 따라 리플레시토큰을으로 토큰을 갱신하도록 알려야 한다.
            return 0;
        }
    }

    public string RefreshTokenGenerate()
    {
        //var refreshToken = new UserRefreshToken
        //{
        //    //랜덤하게 값 생성
        //    RefreshToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(64)),
        //    //설정된 시간(초)만큼 시간을 설정한다.
        //    ExpiresTime = DateTime.UtcNow.AddSeconds(this._JwtAuthSetting.RefreshTokenLifetime),
        //};
            
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }


    public long? ClaimDataGet(ClaimsPrincipal claimsPrincipal)
    {
        //인증정보 확인
        long nUser = 0;
        foreach (Claim item in claimsPrincipal.Claims.ToArray())
        {
            if (item.Type == "idUser")
            {//인증 정보가 있다.
                nUser = Convert.ToInt64(item.Value);
                break;
            }
        }

        return nUser;
    }
}