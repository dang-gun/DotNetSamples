namespace JwtAuth;

using JwtAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelsDB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi_JwtAuthTest.Faculty.JwtAuth;

/// <summary>
/// DgJwtAuth���� ��ū ó���� ���� ��ƿ �������̽�
/// </summary>
public static class DgJwtAuthUtilsBuilder
{
    public static IServiceCollection AddDgJwtAuthUtilsBuilder(
        this IServiceCollection services
        , DgJwtAuthSettingModel aaa)
    {

        //builder.addcl
        //services.Configure<DgJwtAuthSettingModel>();

        services.AddDbContext<DgJwtAuthDbContext>(
            options => options.UseInMemoryDatabase(databaseName: "Test"));


        services.AddSingleton<Func<DisposableScopedContextWrapper>>(provider => () =>
        {
            var scope = provider.CreateScope();
            return new DisposableScopedContextWrapper(scope);
        });

        return services;
    }
}