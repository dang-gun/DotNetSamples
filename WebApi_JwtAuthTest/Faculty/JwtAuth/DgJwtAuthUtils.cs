namespace JwtAuth;

using JwtAuth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelsDB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// DgJwtAuth에서 토큰 처리를 위한 유틸 인터페이스
/// </summary>
public interface DgJwtAuthUtilsInterface
{
    /// <summary>
    /// 엑세스 토큰 생성
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public string AccessTokenGenerate(User account);

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
public class DgJwtAuthUtils : DgJwtAuthUtilsInterface
{
    /// <summary>
    /// 설정된 세팅 정보
    /// </summary>
    private readonly DgJwtAuthSettingModel _JwtAuthSetting;

    public DgJwtAuthUtils(IOptions<DgJwtAuthSettingModel> appSettings)
    {
        _JwtAuthSetting = appSettings.Value;

        if (_JwtAuthSetting.Secret == null 
            || _JwtAuthSetting.Secret == string.Empty)
        {//시크릿 값이 없다.

            //새로 생성한다.
            _JwtAuthSetting.Secret 
                = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }


    
    public string AccessTokenGenerate(User account)
    {
        // generate token that is valid for 15 minutes
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_JwtAuthSetting.Secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("idUser", account.idUser.ToString()) }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public int AccessTokenValidate(string token)
    {
        if (string.IsNullOrEmpty(token))
        {//전달된 토큰 값이 없다.
            return -1;
        }

        JwtSecurityTokenHandler tokenHandler 
            = new JwtSecurityTokenHandler();
        byte[] byteKey 
            = Encoding.ASCII.GetBytes(_JwtAuthSetting.Secret!);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
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