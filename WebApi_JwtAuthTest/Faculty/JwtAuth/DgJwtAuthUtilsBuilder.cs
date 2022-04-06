
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelsDB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DGAuthServer;

/// <summary>
/// DG Auth Server Service를 위한 빌더 구현
/// </summary>
public static class DgJwtAuthUtilsBuilder
{
    /// <summary>
    /// 서비스 빌더
    /// </summary>
    /// <param name="services"></param>
    /// <param name="settingData"></param>
    /// <returns></returns>
    public static IServiceCollection AddDgAuthServerBuilder(
        this IServiceCollection services
        , DgJwtAuthSettingModel settingData
        , Action<DbContextOptionsBuilder>? actDbContextOnConfiguring)
    {

        //세팅 데이터 저장
        DGAuthServerGlobal.Setting.ToCopy(settingData);

        //builder.addcl
        //services.Configure<DgJwtAuthSettingModel>();

        //옵션 전달
        services.Configure<DgJwtAuthSettingModel>(options =>
        {
            options.ToCopy(DGAuthServerGlobal.Setting);
        });

        if (null != actDbContextOnConfiguring)
        {
            DGAuthServerGlobal.ActDbContextOnConfiguring
                = actDbContextOnConfiguring;
        }
        else
        {
            //자체적으로 사용할 데이터 베이스
            DGAuthServerGlobal.ActDbContextOnConfiguring
                = (options => options.UseInMemoryDatabase(databaseName: "DGAuthServer_DB"));
        }

        //테이블 생성
        using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
        {
            db1.Database.EnsureCreated();
        }


        return services;
    }

    /// <summary>
    /// 어플리케이션(미들웨어) 빌더
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseDgAuthServerAppBuilder(
        this IApplicationBuilder app)
    {

        //JwtAuth 미들웨어 주입
        app.UseMiddleware<DgJwtAuthMiddleware>();
        return app;
    }
}

