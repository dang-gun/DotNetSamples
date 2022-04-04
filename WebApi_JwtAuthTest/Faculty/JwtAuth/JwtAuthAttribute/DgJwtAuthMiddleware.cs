namespace JwtAuth;

using JwtAuth;
using JwtAuth.Models;
using Microsoft.Extensions.Options;
using ModelsDB;
using System.Security.Claims;

/// <summary>
/// 인증 미들웨어
/// </summary>
/// <remarks>인</remarks>
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

    public async Task Invoke(
        HttpContext context
        , DgJwtAuthUtilsInterface jwtUtils)
    {
        //추출된 토큰
        string sToken = string.Empty;
        //토큰이 있는지 여부
        bool bToken = false;

        if (string.Empty == _appSettings.AuthTokenStartName)
        {//인증 토큰 시작 단어를 사용하지 않는다.

            //토큰 추출
            string? token2
                = context.Request
                    .Headers["Authorization"]
                    .FirstOrDefault();

            if (null != token2
                && string.Empty != token2)
            {//토큰 내용이 있다.
                bToken = true;
                sToken = token2!;
            }
        }
        else
        {//인증 토큰 시작 단어를 사용한다.

            //토큰이 있으면 여기서 2개 이상 나온다.
            string[]? arrToken
                = context.Request
                    .Headers["Authorization"]
                    .FirstOrDefault()?
                    .Split(_appSettings.AuthTokenStartName_Complete);

            if (null != arrToken
                && 1 < arrToken.Length)
            {//토큰 내용이 있다.
                bToken = true;
                sToken = arrToken.Last();
            }
        }




        //토큰 정보를 기준으로 속성에 전달하기위한 값 처리를 한다.
        int idUser = 0;
        if (true == bToken)
        {//토큰이 있다.

            //토큰에서 idUser 추출
            idUser = jwtUtils.AccessTokenValidate(sToken);
        }
        else
        {//토큰 없음
            idUser = -1;
        }

        //처리된 토큰 정보를 전달한다.
        //엑세스 토큰에 데이터가 있으면 클레임데이터를 추가해 준다.
        var claims
            = new List<Claim>
                {
                        new Claim("idUser", idUser.ToString()!)
                };

        //HttpContext에 클래임 정보를 넣어준다.
        ClaimsIdentity appIdentity = new ClaimsIdentity(claims);
        context.User.AddIdentity(appIdentity);



        await _next(context);
    }
}