

using JwtAuth;
using JwtAuth.Models;
using Microsoft.Extensions.Options;
using ModelsDB;
using System.Security.Claims;

namespace DGAuthServer;

/// <summary>
/// ���� �̵����
/// </summary>
/// <remarks>��</remarks>
public class DgJwtAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly DgJwtAuthSettingModel _appSettings;

    public DgJwtAuthMiddleware(RequestDelegate next
        , IOptions<DgJwtAuthSettingModel> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    /// <summary>
    /// ���� ���޿� �̵� ����
    /// </summary>
    /// <param name="context"></param>
    /// <param name="jwtUtils"></param>
    /// <returns></returns>
    public async Task Invoke(
        HttpContext context
        , DGAuthServerInterface jwtUtils)
    {
        //����� ��ū
        string sToken = string.Empty;
        //��ū�� �ִ��� ����
        bool bToken = false;

        if (string.Empty == _appSettings.AuthTokenStartName)
        {//���� ��ū ���� �ܾ ������� �ʴ´�.

            //��ū ����
            string? token2
                = context.Request
                    .Headers["Authorization"]
                    .FirstOrDefault();

            if (null != token2
                && string.Empty != token2)
            {//��ū ������ �ִ�.
                bToken = true;
                sToken = token2!;
            }
        }
        else
        {//���� ��ū ���� �ܾ ����Ѵ�.

            //��ū�� ������ ���⼭ 2�� �̻� ���´�.
            string[]? arrToken
                = context.Request
                    .Headers["Authorization"]
                    .FirstOrDefault()?
                    .Split(_appSettings.AuthTokenStartName_Complete);

            if (null != arrToken
                && 1 < arrToken.Length)
            {//��ū ������ �ִ�.
                bToken = true;
                sToken = arrToken.Last();
            }
        }




        //��ū ������ �������� �Ӽ��� �����ϱ����� �� ó���� �Ѵ�.
        int idUser = 0;
        if (true == bToken)
        {//��ū�� �ִ�.

            //��ū���� idUser ����
            idUser = jwtUtils.AccessTokenValidate(sToken);
        }
        else
        {//��ū ����
            idUser = -1;
        }

        //ó���� ��ū ������ �����Ѵ�.
        //������ ��ū�� �����Ͱ� ������ Ŭ���ӵ����͸� �߰��� �ش�.
        var claims
            = new List<Claim>
                {
                        new Claim("idUser", idUser.ToString()!)
                };

        //HttpContext�� Ŭ���� ������ �־��ش�.
        ClaimsIdentity appIdentity = new ClaimsIdentity(claims);
        context.User.AddIdentity(appIdentity);



        await _next(context);
    }
}