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
/// DgJwtAuth���� ��ū ó���� ���� ��ƿ �������̽�
/// </summary>
public interface DgJwtAuthUtilsInterface
{
    /// <summary>
    /// ������ ��ū ����
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public string AccessTokenGenerate(User account);

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
public class DgJwtAuthUtils : DgJwtAuthUtilsInterface
{
    /// <summary>
    /// ������ ���� ����
    /// </summary>
    private readonly DgJwtAuthSettingModel _JwtAuthSetting;

    public DgJwtAuthUtils(IOptions<DgJwtAuthSettingModel> appSettings)
    {
        _JwtAuthSetting = appSettings.Value;

        if (_JwtAuthSetting.Secret == null 
            || _JwtAuthSetting.Secret == string.Empty)
        {//��ũ�� ���� ����.

            //���� �����Ѵ�.
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
        {//���޵� ��ū ���� ����.
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