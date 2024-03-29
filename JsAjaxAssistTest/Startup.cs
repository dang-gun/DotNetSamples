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
        /// 인증서버 주소
        /// </summary>
        private string AuthUrl = "";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //인증 정보
            this.AuthUrl = Configuration["AuthServer:Url"];
            GlobalStatic.TokenProc = new TokenProcess(this.AuthUrl);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //7. OAuth2 미들웨어(IdentityServer) 설정
            //AddCustomUserStore : 앞에서 만든 확장메소드를 추가
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddSigningCredential()
                .AddExtensionGrantValidator<MyExtensionGrantValidator>()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddCustomUserStore();

            //API모델을 파스칼 케이스 유지하기
            services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

            //클라이언트 인증 요청 정보
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.Audience = "apiApp";

                //인증서버의 주소
                o.Authority = AuthUrl;
                o.RequireHttpsMetadata = false;
                //인증서버에서 선언한 권한
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

            //3.0 api 라우트
            app.UseRouting();

            //09. OAuth2 미들웨어(IdentityServer) CROS 접근 권한 문제
            //app.UseCors(options =>
            //{
            //    //전체 허용
            //    options.AllowAnyOrigin();
            //});
            //OAuth2 미들웨어(IdentityServer) 설정
            app.UseIdentityServer();
            //인증서버 사용 설정
            app.UseAuthorization();

            //8. 프로젝트 미들웨어 기능 설정
            //웹사이트 기본파일 읽기 설정
            app.UseDefaultFiles();
            //wwwroot 파일읽기
            app.UseStaticFiles();
            //http요청을 https로 리디렉션합니다.
            //https를 허용하지 않았다면 제거 합니다.
            //https://docs.microsoft.com/ko-kr/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.0&tabs=visual-studio
            app.UseHttpsRedirection();

            //인증 요청
            app.UseAuthentication();
            //에러가 났을때 Http 상태코드를 전달하기위한 설정
            app.UseStatusCodePages();


            //3.0 api 라우트 끝점
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
