
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
/// DG Auth Server Service�� ���� ���� ����
/// </summary>
public static class DgJwtAuthUtilsBuilder
{
    /// <summary>
    /// ���� ����
    /// </summary>
    /// <param name="services"></param>
    /// <param name="settingData"></param>
    /// <returns></returns>
    public static IServiceCollection AddDgAuthServerBuilder(
        this IServiceCollection services
        , DgJwtAuthSettingModel settingData
        , Action<DbContextOptionsBuilder>? actDbContextOnConfiguring)
    {

        //���� ������ ����
        DGAuthServerGlobal.Setting.ToCopy(settingData);

        //builder.addcl
        //services.Configure<DgJwtAuthSettingModel>();

        //�ɼ� ����
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
            //��ü������ ����� ������ ���̽�
            DGAuthServerGlobal.ActDbContextOnConfiguring
                = (options => options.UseInMemoryDatabase(databaseName: "DGAuthServer_DB"));
        }

        //���̺� ����
        using (DgJwtAuthDbContext db1 = new DgJwtAuthDbContext())
        {
            db1.Database.EnsureCreated();
        }


        return services;
    }

    /// <summary>
    /// ���ø����̼�(�̵����) ����
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseDgAuthServerAppBuilder(
        this IApplicationBuilder app)
    {

        //JwtAuth �̵���� ����
        app.UseMiddleware<DgJwtAuthMiddleware>();
        return app;
    }
}

