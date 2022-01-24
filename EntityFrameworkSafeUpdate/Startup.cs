using EntityFrameworkSafeUpdate.Global;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelsDB;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkSafeUpdate
{
    /// <summary>
    /// https://stackoverflow.com/questions/15669383/how-to-inc-dec-multi-user-safe-in-entity-framework-5/15669840#15669840
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;

            //���� ��� ����
            GlobalStatic.Dir_LocalRoot = env.ContentRootPath;

            //DB Ŀ���� ��Ʈ�� �޾ƿ���
            string sConnectStringSelect = Configuration["SelectDBConnectionString"];

            GlobalStatic.DBType = Configuration[sConnectStringSelect + ":DBType"];
            GlobalStatic.DBString = Configuration[sConnectStringSelect + ":ConnectionString"];

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //API���� �Ľ�Į ���̽� �����ϱ�
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver
                        = new DefaultContractResolver();
                });

            services.AddDbContext<ModelsDbContext>();
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

            //8. ������Ʈ �̵���� ��� ����
            //������Ʈ �⺻���� �б� ����
            app.UseDefaultFiles();
            //wwwroot �����б�
            app.UseStaticFiles();

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
