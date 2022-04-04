

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
/// DgJwtAuth���� ��ū ó���� ���� ��ƿ �������̽�
/// </summary>
public interface DGAuthServerInterface
{
    /// <summary>
    /// ������ ��ū ����
    /// </summary>
    /// <param name="idUser">���� ������ ���� ���� ��ȣ</param>
    /// <returns></returns>
    public string AccessTokenGenerate(long idUser);

    /// <summary>
    /// ������ ��ū Ȯ��.
    /// <para> </para>
    /// </summary>
    /// <remarks>�̵������� ȣ���ؼ� ����Ѵ�.</remarks>
    /// <param name="token"></param>
    /// <returns>ã�Ƴ� idUser, ��ū ��ü�� ������ -1, ��ū�� ��ȿ���� ������ 0 </returns>
    public int AccessTokenValidate(string token);

    /// <summary>
    /// ���÷��� ��ū ����.
    /// </summary>
    /// <remarks>�ߺ��˻�� ���� �����Ƿ� �ʿ��ϴٸ� ȣ�����ʿ��� �ߺ��˻縦 �ؾ� �Ѵ�.</remarks>
    /// <returns></returns>
    public string RefreshTokenGenerate();

    /// <summary>
    /// HttpContext.User�� Ŭ������ �˻��Ͽ� ���� ���������� �޴´�.
    /// </summary>
    /// <param name="claimsPrincipal"></param>
    /// <returns></returns>
    public long? ClaimDataGet(ClaimsPrincipal claimsPrincipal);
}

/// <summary>
/// DgJwtAuth���� ��ū ó��
/// </summary>
public class DGAuthServer : DGAuthServerInterface
{
    /// <summary>
    /// ������ ���� ����
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
        {//��ũ�� ���� ����.

            //���� �����Ѵ�.
            _JwtAuthSetting.Secret 
                = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }


    
    public string AccessTokenGenerate(long idUser)
    {

        //��ũ�� Ű �ӽ� ����
        string sSecret = string.Empty;
        
        if (true == this._JwtAuthSetting.SecretAlone)
        {//ȥ�ڻ���ϴ� ��ũ��

            DgJwtAuthAccessToken? findAT = null;

            using (DgJwtAuthDbContext db1 = _func().Context)
            {
                findAT 
                    = db1.DgJwtAuthAccessToken
                        .Where(w => w.idUser == idUser)
                        .FirstOrDefault();

                if (null != findAT)
                {//����ϴ� ��ũ���� �ִ�.

                    //����
                    sSecret = findAT.Secret;
                }
                else
                {//����ϴ� ��ũ���� ����.
                    DgJwtAuthAccessToken newAT = new DgJwtAuthAccessToken();
                    //����� �Է�
                    newAT.idUser = idUser;
                    //���ο� ��ũ���� �����Ѵ�.
                    sSecret = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                    newAT.Secret = sSecret;

                    //db�� ����
                    db1.Add(newAT);
                    db1.SaveChanges();
                }
            }//end using db1
        }
        else
        {
            //���� ��ũ���� ����.
            sSecret = this._JwtAuthSetting.Secret!;
        }

        //��ũ���� ����Ʈ �迭�� ��ȯ
        byte[] byteSecretKey = new byte[0];
        byteSecretKey = Encoding.ASCII.GetBytes(sSecret);


        //jwt ���� ��ū �ڵ鷯
        JwtSecurityTokenHandler tokenHandler 
            = new JwtSecurityTokenHandler();

        //������Ű ������ �ʿ��� ������ �Է��Ѵ�.
        SecurityTokenDescriptor tokenDescriptor 
            = new SecurityTokenDescriptor
            {
                //�߰��� ���� ����(Ŭ����)
                Subject = new ClaimsIdentity(new[] { new Claim("idUser", idUser.ToString()) }),
                //��ȿ�Ⱓ
                Expires = DateTime.UtcNow.AddSeconds(this._JwtAuthSetting.AccessTokenLifetime),
                //��ȣȭ ���
                SigningCredentials 
                    = new SigningCredentials(new SymmetricSecurityKey(byteSecretKey)
                                                , SecurityAlgorithms.HmacSha256Signature)
            };

        //��ū ����
        SecurityToken token 
            = tokenHandler.CreateToken(tokenDescriptor);

        //����ȭ
        StringBuilder sbToken = new StringBuilder();
        if (true == this._JwtAuthSetting.SecretAlone)
        {//ȥ �ڻ���ϴ� ��ũ��

            //�Ǿտ� ���� ������ȣ�� �ٿ��ش�.
            sbToken.Append(idUser);
            //���� ��ȣ
            sbToken.Append(this._JwtAuthSetting.SecretAloneDelimeter);
        }

        //������� ��ū �߰�
        sbToken.Append(tokenHandler.WriteToken(token));

        return sbToken.ToString();
    }

    public int AccessTokenValidate(string sToken)
    {


        if (string.IsNullOrEmpty(sToken))
        {//���޵� ��ū ���� ����.
            return -1;
        }


        //��ū
        string sTokenCut = string.Empty;
        //ã�Ƴ� ���� ��ȣ
        long idUser = 0;
        //��ũ�� Ű �ӽ� ����
        string sSecret = string.Empty;

        //ȥ
        if (true == this._JwtAuthSetting.SecretAlone)
		{//ȥ�ڻ���ϴ� ��ũ��

			//�̰�� �տ� ������ȣ�� ���� �и��Ѵ�.
			string[] arrCutToke = sToken.Split(this._JwtAuthSetting.SecretAloneDelimeter);

			if (2 > arrCutToke.Length)
			{//������ ��ū�� ���� ��ȣ�� ����.
				return 0;
			}

			if (false == Int64.TryParse(arrCutToke[0], out idUser))
			{//���ڷ� ��ȯ�� �� ����.
				return 0;
			}
			else if (0 == idUser)
			{//���� ������ �߸� �Ǿ���.
				return 0;
			}

            //�߸� ������ ����
			sTokenCut = arrCutToke[1];

            //
            DgJwtAuthAccessToken? findAT = null;

            //����� ��ũ�� �˻�
            using (DgJwtAuthDbContext db1 = _func().Context)
            {
                findAT
                    = db1.DgJwtAuthAccessToken
                        .Where(w => w.idUser == idUser)
                        .FirstOrDefault();

            }//end using db1

            if (null == findAT
                || string.Empty == findAT.Secret)
            {//��ũ�� ������ ����.
                return 0;
            }

            //ã�� ��ũ�� ����
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

            //ã�� ���̵�
            return accountId;
        }
        catch
        {//��ū�� �ؼ����� ���ߴ�.
            
            //��ū�� ����������� �ؼ����� ���ϸ� 0 ������ ��������
            //��Ȳ�� ���� ���÷�����ū������ ��ū�� �����ϵ��� �˷��� �Ѵ�.
            return 0;
        }
    }

    public string RefreshTokenGenerate()
    {
        //var refreshToken = new UserRefreshToken
        //{
        //    //�����ϰ� �� ����
        //    RefreshToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(64)),
        //    //������ �ð�(��)��ŭ �ð��� �����Ѵ�.
        //    ExpiresTime = DateTime.UtcNow.AddSeconds(this._JwtAuthSetting.RefreshTokenLifetime),
        //};
            
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }


    public long? ClaimDataGet(ClaimsPrincipal claimsPrincipal)
    {
        //�������� Ȯ��
        long nUser = 0;
        foreach (Claim item in claimsPrincipal.Claims.ToArray())
        {
            if (item.Type == "idUser")
            {//���� ������ �ִ�.
                nUser = Convert.ToInt64(item.Value);
                break;
            }
        }

        return nUser;
    }
}