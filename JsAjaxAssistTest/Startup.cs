using IdentityServer4_Custom.IdentityServer4;
using IdentityServer4_Custom.IdentityServer4.AuthRequest;
using JsAjaxAssistTest.Global;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsAjaxAssistTest
{
    public class Startup
    {
        /// <summary>
        /// �������� �ּ�
        /// </summary>
        private string AuthUrl = "";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //���� ����
            this.AuthUrl = Configuration["AuthServer:Url"];
            GlobalStatic.TokenProc = new TokenProcess(this.AuthUrl);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //7. OAuth2 �̵����(IdentityServer) ����
            //AddCustomUserStore : �տ��� ���� Ȯ��޼ҵ带 �߰�
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddSigningCredential()
                .AddExtensionGrantValidator<MyExtensionGrantValidator>()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddCustomUserStore();

            //API���� �Ľ�Į ���̽� �����ϱ�
            services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

            //Ŭ���̾�Ʈ ���� ��û ����
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.Audience = "apiApp";

                //���������� �ּ�
                o.Authority = AuthUrl;
                o.RequireHttpsMetadata = false;
                //������������ ������ ����
                o.Audience = "dataEventRecords";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //3.0 api ���Ʈ
            app.UseRouting();

            //09. OAuth2 �̵����(IdentityServer) CROS ���� ���� ����
            //app.UseCors(options =>
            //{
            //    //��ü ���
            //    options.AllowAnyOrigin();
            //});
            //OAuth2 �̵����(IdentityServer) ����
            app.UseIdentityServer();
            //�������� ��� ����
            app.UseAuthorization();

            //8. ������Ʈ �̵���� ��� ����
            //������Ʈ �⺻���� �б� ����
            app.UseDefaultFiles();
            //wwwroot �����б�
            app.UseStaticFiles();
            //http��û�� https�� ���𷺼��մϴ�.
            //https�� ������� �ʾҴٸ� ���� �մϴ�.
            //https://docs.microsoft.com/ko-kr/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.0&tabs=visual-studio
            app.UseHttpsRedirection();

            //���� ��û
            app.UseAuthentication();
            //������ ������ Http �����ڵ带 �����ϱ����� ����
            app.UseStatusCodePages();


            //3.0 api ���Ʈ ����
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
