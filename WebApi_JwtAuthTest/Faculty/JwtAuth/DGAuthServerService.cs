
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelsDB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace DGAuthServer;


/// <summary>
/// DgJwtAuth���� ��ū ó��.
/// ���񽺸� �����Ұ��̰� �����ΰ������� ����� �����ϰ� �������� �ʴ°����� ����� ���ȴ�.
/// ���񽺸� �����ϸ� ������ ���µ� �ʹ� ���� �ڵ带 ����ϴµ�
/// �� ����� ���������̰� ��ǻ� �̱������� �����ص� ����ƽ�� �����ϰ� �����ϰ� �ȴ�.
/// </summary>
public class DGAuthServerService
{
    /// <summary>
    /// ������ ��ū ����
    /// </summary>
    /// <param name="idUser">���� ������ ���� ���� ��ȣ</param>
    /// <param name="sClass">�� ��ū�� �з��ϱ� ���� �̸�</param>
    /// <param name="response">�߰� ó���� ���� ��������</param>
    /// <returns></returns>
    public string AccessTokenGenerate(
        long idUser
        , string sClass
        , HttpResponse? response)
    {

        //��ũ�� Ű �ӽ� ����
        string sSecret = string.Empty;
        
        if (true == DGAuthServerGlobal.Setting.SecretAlone)
        {//ȥ�ڻ���ϴ� ��ũ��

            DgJwtAuthAccessToken? findAT = null;

            using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
            {
                findAT 
                    = db1.DGAuthServer_AccessToken
                        .Where(w => w.idUser == idUser
                                && w.Class == sClass)
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
                    newAT.Class = sClass;
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
            sSecret = DGAuthServerGlobal.Setting.Secret!;
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
                Subject = new ClaimsIdentity(
                            new[] { new Claim(DGAuthServerGlobal.Setting.UserIdName
                                            , idUser.ToString()) }),
                //��ȿ�Ⱓ
                Expires = DateTime.UtcNow.AddSeconds(DGAuthServerGlobal.Setting.AccessTokenLifetime),
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
        if (true == DGAuthServerGlobal.Setting.SecretAlone)
        {//ȥ �ڻ���ϴ� ��ũ��

            //�Ǿտ� ���� ������ȣ�� �ٿ��ش�.
            sbToken.Append(idUser);
            //���� ��ȣ
            sbToken.Append(DGAuthServerGlobal.Setting.SecretAloneDelimeter);
        }

        //������� ��ū �߰�
        sbToken.Append(tokenHandler.WriteToken(token));



        if (true == DGAuthServerGlobal.Setting.AccessTokenCookie
            && null != response)
        {//��Ű ���

            //���÷��� ��ū�� �����Ѵ�.
            this.Cookie_AccessToken(sbToken.ToString(), response);
        }

        return sbToken.ToString();
    }

    /// <summary>
    /// ������ ��ū Ȯ��.
    /// <para> </para>
    /// </summary>
    /// <remarks>�̵������� ȣ���ؼ� ����Ѵ�.</remarks>
    /// <param name="token"></param>
    /// <returns>ã�Ƴ� idUser, ��ū ��ü�� ������ -1, ��ū�� ��ȿ���� ������ 0 </returns>
    public long AccessTokenValidate(
        string sToken)
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

        //����� ��ũ�� Ű ã��
        if (true == DGAuthServerGlobal.Setting.SecretAlone)
		{//ȥ�ڻ���ϴ� ��ũ��

			//�̰�� �տ� ������ȣ�� ���� �и��Ѵ�.
			string[] arrCutToke = sToken.Split(DGAuthServerGlobal.Setting.SecretAloneDelimeter);

			if (2 > arrCutToke.Length)
			{//������ ��ū�� ���� ��ȣ�� ����.
				return 0;
			}

			if (false == Int64.TryParse(arrCutToke[0], out idUser))
			{//���ڷ� ��ȯ�� �� ����.
				return 0;
			}
			else if (0 >= idUser)
			{//���� ������ ����.
                
                //���� ������ �߸� �Ǿ���.
				return 0;
			}

            //�߸� �����Ϳ��� ��ū ������ ����
			sTokenCut = arrCutToke[1];

            //ã�� ��������ū ������
            DgJwtAuthAccessToken? findAT = null;

            //����� ��ũ�� �˻�
            using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
            {
                findAT
                    = db1.DGAuthServer_AccessToken
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
            sSecret = DGAuthServerGlobal.Setting.Secret!;

        }



        //���� �м� ���� ****************
		JwtSecurityTokenHandler tokenHandler 
            = new JwtSecurityTokenHandler();
        //���� ��ũ���� ����Ʈ �迭�� ��ȯ
        byte[] byteKey 
            = Encoding.ASCII.GetBytes(sSecret);
        try
        {
            //��ū �ؼ��� �����Ѵ�.
            tokenHandler.ValidateToken(sToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(byteKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
            //ã�� ũ���ӿ��� ���� ������ȣ�� �����Ѵ�.
            long accountId 
                = Int64.Parse(jwtToken.Claims
                                .First(x => x.Type == DGAuthServerGlobal.Setting.UserIdName)
                                .Value);

            //ã�� ���̵�
            return accountId;
        }
        catch
        {//��ū�� �ؼ����� ���ߴ�.
            
            //��ū�� ����������� �ؼ����� ���ϸ� 0 ������ ��������
            //��Ȳ�� ���� ���÷��� ��ū���� ��ū�� �����ϵ��� �˷��� �Ѵ�.
            return 0;
        }
    }

    /// <summary>
    /// ������ ��ū�� �����Ŵ
    /// </summary>
    /// <remarks>
    /// ������ ��ū�� �����ų ����� ����<br />
    /// ���� ��ũ�� Ű�� ������϶��� ����ũ�� �����ϴ�.<br />
    /// ��Ű�� ������̶�� ��Ű�� �����ִ� ����� �Ѵ�.<br />
    /// bAllRevoke�� true��� ���� ��ũ�� Ű�� ��߱� �Ǹ鼭 
    /// ���� ��������ū�� ����� �� ���� �ȴ�.
    /// </remarks>
    /// <param name="bAllRevoke">Ŭ������ ������� ��ü ������ ��ū�� ����ũ�Ѵ�.
    /// ���� ��ũ���� ������̶�� false�϶��� ���� ��ũ���� ������ �ʴ´�.
    /// </param>
    /// <param name="idUser"></param>
    /// <param name="sClass"></param>
    /// <param name="response"></param>
    /// <returns></returns>
    public void AccessTokenRevoke(
        bool bAllRevoke
        , long idUser
        , string sClass
        , HttpResponse? response)
    {
        using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
        {
            IQueryable<DgJwtAuthAccessToken> iqFindAT;

            if (true == bAllRevoke)
            {//��ü �˻�
                iqFindAT
                    = db1.DGAuthServer_AccessToken
                        .Where(w => w.idUser == idUser);
            }
            else
            {//��� �˻�
                iqFindAT
                    = db1.DGAuthServer_AccessToken
                        .Where(w => w.idUser == idUser
                                && w.Class == sClass);
            }

            //����� ������ �����.
            //���� ��ũ���� ������̶�� ��������ū�� ��û�ϸ鼭 �ٽ� �����ȴ�.
            //�׷��� ���⼭�� ����⸸ �ϸ�ȴ�.
            db1.DGAuthServer_AccessToken.RemoveRange(iqFindAT);

            db1.SaveChanges();
        }//end using db1


        if (true == DGAuthServerGlobal.Setting.AccessTokenCookie
            && null != response)
        {//��Ű ���

            //���÷��� ��ū�� �����Ѵ�.
            this.Cookie_AccessToken(string.Empty, response);
        }
    }


    /// <summary>
    /// ���÷��� ��ū ����.
    /// </summary>
    /// <remarks>�ߺ��˻� �� ��ȿ���˻縦 �ϰ��� ���ǿ� �´� ��ū�� ����(����)�Ѵ�.</remarks>
    /// <param name="typeUsage"></param>
    /// <param name="idUser">�� ��ū�� ������ ������ ������ȣ</param>
    /// <param name="sClass">�� ��ū�� �з��ϱ� ���� �̸�</param>
    /// <param name="response">�߰� ó���� ���� ��������</param>
    /// <returns></returns>
    public string RefreshTokenGenerate(
        RefreshTokenUsageType? typeUsage
        , long idUser
        , string sClass
        , HttpResponse? response)
    {
        string sReturn = string.Empty;

        //���� �ð�
        DateTime dtNow = DateTime.Now;

        RefreshTokenUsageType bNewTokenFinal = RefreshTokenUsageType.None;
        if (null != typeUsage)
        {//���޵� �ɼ��� �ִ�.
            bNewTokenFinal = (RefreshTokenUsageType)typeUsage;
        }
        else
        {
            //������ ������ �о� ����Ѵ�.
            bNewTokenFinal 
                = DGAuthServerGlobal.Setting.RefreshTokenReUseType;
        }


        using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
        {
            bool bNew = false;


            switch (bNewTokenFinal)
            {
                case RefreshTokenUsageType.OneTimeOnly:
                    {
                        //���� ��ū�� ����
                        bNew = true;
                    }
                    break;

                case RefreshTokenUsageType.OneTimeOnlyDelay:
                case RefreshTokenUsageType.ReUse:
                case RefreshTokenUsageType.ReUseAddTime:
                    {
                        //���� ��ū�� �ִ��� ã�´�.
                        DgJwtAuthRefreshToken? findRT
                            = db1.DGAuthServer_RefreshToken
                                .Where(w => w.idUser == idUser
                                        && w.Class == sClass)
                                .FirstOrDefault();

                        if (null != findRT)
                        {//���� ��ū�� �ִ�.

                            //��ȿ���� ���� ��ġ��
                            findRT.ActiveCheck();

                            if (true == findRT.ActiveIs)
                            {//��ū�� ��ȿ�ϴ�.

                                //����ϴ� ��ū ����
                                sReturn = findRT.RefreshToken;

                                if (RefreshTokenUsageType.ReUseAddTime == bNewTokenFinal)
                                {
                                    //���� �ð��� �·��ش�.
                                    findRT.ExpiresTime
                                        = DateTime.UtcNow
                                            .AddSeconds(DGAuthServerGlobal.Setting
                                                            .RefreshTokenLifetime);
                                }
                                else if (RefreshTokenUsageType.OneTimeOnlyDelay == bNewTokenFinal)
                                {

                                    //���� ��ū�� ������¥�� Ȯ���Ѵ�.
                                    if (findRT.GenerateTime.AddSeconds(DGAuthServerGlobal.Setting.OneTimeOnlyDelayTime)
                                         < dtNow)
                                    {//�����ð� + ������ �ð� ���� ���� �ð��� ���Ĵ�

                                        //���� ��ū�� ����
                                        bNew = true;
                                    }
                                    else
                                    {//�ƴϸ�
                                     
                                        //���� ��ū ���
                                        bNew = false;
                                    }   
                                }
                            }
                            else
                            {//��ū�� ���� �ƴ�.

                                //���� ��ū�� ����
                                bNew = true;
                            }   
                        }
                        else
                        {//���� ��ū�� ����.

                            //���� ��ū�� ����
                            bNew = true;
                        }
                    }
                    break;

                case RefreshTokenUsageType.None:
                default:
                    break;
            }

            if (true == bNew)
            {//��ū�� ���� �����ؾ� �Ѵ�.

                sReturn = this.RefreshTokenGenerate();
                //���̺� �����Ѵ�.
                DgJwtAuthRefreshToken newRT = new DgJwtAuthRefreshToken()
                {
                    idUser = idUser,
                    Class = sClass,
                    RefreshToken = sReturn,
                    GenerateTime = dtNow,
                    ExpiresTime
                        = DateTime.UtcNow
                            .AddSeconds(DGAuthServerGlobal.Setting
                                            .RefreshTokenLifetime),

                };
                newRT.ActiveCheck();
                //db�� �߰�
                db1.DGAuthServer_RefreshToken.Add(newRT);


                //���� ��ū ���� ó��
                //��� �˻�
                IQueryable<DgJwtAuthRefreshToken> iqFindRT
                    = db1.DGAuthServer_RefreshToken
                        .Where(w => w.idUser == idUser
                                && w.Class == sClass
                                && true == w.ActiveIs);
                //linq�� �����͸� �����Ҷ��� ���� �ַ����� �ƴϴ�.
                //�ݺ������� ���������ϴ� ���� �ξ� ���ɿ� ������ �ȴ�.
                foreach (DgJwtAuthRefreshToken itemURT in iqFindRT)
                {
                    //���� �ð��� ������
                    itemURT.RevokeTime = dtNow;
                    itemURT.ActiveCheck();
                }

            }//end if (true == bNew)

            db1.SaveChanges();
        }//end using db1

        if (true == DGAuthServerGlobal.Setting.RefreshTokenCookie
            && null != response)
        {//��Ű ���

            //���÷��� ��ū�� �����Ѵ�.
            this.Cookie_RefreshToken(sReturn, response);
        }
            
        return sReturn;
    }

    /// <summary>
    /// ���÷��� ��ū���� ���� ������ȣ�� ã�´�.
    /// </summary>
    /// <param name="sRefreshToken"></param>
    /// <param name="sClass"></param>
    /// <returns>��ū�� ��ȿ���� ������ 0</returns>
    public long RefreshTokenFindUser(
        string sRefreshToken
        , string sClass)
    {
        long idUser = 0;

        using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
        {
            DgJwtAuthRefreshToken? findRT
                = db1.DGAuthServer_RefreshToken
                    .Where(w => w.RefreshToken == sRefreshToken
                            && w.ActiveIs == true
                            && w.Class == sClass)
                    .FirstOrDefault();

            if (null != findRT)
            {//ã��

                //��ū�� ��ȿ���� Ȯ��
                findRT.ActiveCheck();
                if (true == findRT.ActiveIs)
                {//��ȿ�ϴ�
                    idUser = findRT.idUser;
                }
                else
                {//�ƴϴ�.
                    idUser = 0;
                }
            }
            else
            {
                idUser = 0;
            }

            db1.SaveChanges();
        }//end using db1

        return idUser;
    }

    /// <summary>
    /// ����������ū�� ���� ó���Ѵ�.
    /// </summary>
    /// <param name="bAllRevoke">Ŭ������ ������� ��ü ���÷��� ��ū�� ����ũ�Ѵ�.</param>
    /// <param name="idUser"></param>
    /// <param name="sClass"></param>
    /// <param name="response"></param>
    public void RefreshTokenRevoke(
        bool bAllRevoke
        , long idUser
        , string sClass
        , HttpResponse? response)
    {
        //���� �ð�
        DateTime dtNow = DateTime.Now;

        using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
        {

            IQueryable<DgJwtAuthRefreshToken> iqFindRT;

            if (true == bAllRevoke)
            {//��ü ����ũ
                iqFindRT = db1.DGAuthServer_RefreshToken
                        .Where(w => w.idUser == idUser);
            }
            else
            {
                iqFindRT = db1.DGAuthServer_RefreshToken
                        .Where(w => w.idUser == idUser
                                && w.Class == sClass);
            }


            //linq�� �����͸� �����Ҷ��� ���� �ַ����� �ƴϴ�.
            //�ݺ������� ���������ϴ� ���� �ξ� ���ɿ� ������ �ȴ�.
            foreach (DgJwtAuthRefreshToken itemURT in iqFindRT)
            {
                //���� �ð��� ������
                itemURT.RevokeTime = dtNow;
                itemURT.ActiveCheck();
            }

            db1.SaveChanges();
        }//end using db1


        if (true == DGAuthServerGlobal.Setting.RefreshTokenCookie
            && null != response)
        {//��Ű ���

            //���÷��� ��ū�� ������ �����Ѵ�.
            this.Cookie_RefreshToken(String.Empty, response);
        }
    }


    /// <summary>
    /// HttpContext.User�� Ŭ������ �˻��Ͽ� ���� ���������� �޴´�.
    /// </summary>
    /// <param name="claimsPrincipal"></param>
    /// <returns></returns>
    public long? ClaimDataGet(ClaimsPrincipal claimsPrincipal)
    {
        //�������� Ȯ��
        long nUser = 0;
        foreach (Claim item in claimsPrincipal.Claims.ToArray())
        {
            if (item.Type == DGAuthServerGlobal.Setting.UserIdName)
            {//���� ������ �ִ�.
                nUser = Convert.ToInt64(item.Value);
                break;
            }
        }

        return nUser;
    }

    /// <summary>
    /// DB�� �ߺ����� �ʴ� ���÷��� ��ū�� �����Ѵ�.
    /// </summary>
    /// <returns></returns>
    private string RefreshTokenGenerate()
    {
        string sReturn = string.Empty;

        using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
        {
            //���� ��ū�� �����ϰ�
            sReturn = this.RefreshTokenGenerate();

            while (true)
            {
                if (false == db1.DGAuthServer_RefreshToken.Any(a => a.RefreshToken == sReturn))
                {
                    //���ο� ���̸� �Ϸ�
                    break;
                }
            }    
        }//end using db1

        return sReturn;
    }//end RefreshTokenGenerate()

    /// <summary>
    /// ��Ű�� ������ ��ū ������ ��û�Ѵ�.
    /// </summary>
    /// <param name="sToken"></param>
    /// <param name="response">�߰� ó���� ���� ��������</param>
    public void Cookie_AccessToken(string sToken, HttpResponse response)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow
                        .AddSeconds(DGAuthServerGlobal.Setting.AccessTokenLifetime)
        };
        response.Cookies.Append(
            DGAuthServerGlobal.Setting.AccessTokenCookieName
            , sToken
            , cookieOptions);
    }

    /// <summary>
    /// ��⿡ ���÷��� ��ū ������ ��û�Ѵ�.
    /// </summary>
    /// <param name="sToken"></param>
    /// <param name="response">�߰� ó���� ���� ��������</param>
    public void Cookie_RefreshToken(string sToken, HttpResponse response)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow
                        .AddSeconds(DGAuthServerGlobal.Setting.RefreshTokenLifetime)
        };
        response.Cookies.Append(
            DGAuthServerGlobal.Setting.RefreshTokenCookieName
            , sToken
            , cookieOptions);
    }

}