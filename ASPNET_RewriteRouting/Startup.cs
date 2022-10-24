using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace ASPNET_RewriteRouting;

public class Startup
{
	/// <summary>
	/// 
	/// </summary>
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();

		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="app"></param>
	/// <param name="env"></param>
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{

		// Configure the HTTP request pipeline.
		if (env.IsDevelopment())
		{//개발 버전에서만 스웨거 사용
			app.UseSwagger();
			app.UseSwaggerUI();
		}


		//경로 지정
		//var rewrite = new RewriteOptions()
		//	.AddRewrite("home/(.*)", "/home1/$1", true)
		//	.AddRewrite("home", "/home1/", true)

		//	.AddRewrite("admin/(.*)", "/admin1/$1", true)
		//	.AddRewrite("admin", "/admin1/", true)

		//	.AddRewrite("long/(.*)", "/long1/$1", true)
		//	.AddRewrite("long", "/long1/", true)

		//	//.AddRewrite("(.*)", "/production-home/$1", true)
		//	;
		//app.UseRewriter(rewrite);


		
		//3.0 api 라우트
		app.UseRouting();
		//https로 자동 리디렉션
		app.UseHttpsRedirection();



		//기본 페이지
		app.UseDefaultFiles();


		//wwwroot
		//app.UseStaticFiles();
		app
		.UseStaticFiles()
		//.UseStaticFiles(new StaticFileOptions()
		//{
		//	FileProvider = new PhysicalFileProvider(
		//		Path.Combine(env.ContentRootPath
		//						, @"wwwroot\Home1")),
		//	RequestPath = new PathString("/home"),
		//})
		//.UseStaticFiles(new StaticFileOptions()
		//{
		//	FileProvider = new PhysicalFileProvider(
		//		Path.Combine(env.ContentRootPath
		//						, @"wwwroot\production-admin")),
		//	RequestPath = new PathString("/admin"),
		//})
		//.UseStaticFiles(new StaticFileOptions()
		//{
		//	FileProvider = new PhysicalFileProvider(
		//		Path.Combine(env.ContentRootPath
		//				, @"wwwroot\aaa")),
		//	RequestPath = new PathString("/aaa"),
		//})
		;


		app.Map("/home",
		   HomeApp =>
		   {
			   //3.0 api 라우트
			   HomeApp.UseRouting();
			   //https로 자동 리디렉션
			   HomeApp.UseHttpsRedirection();

			   // var rewrite = new RewriteOptions()
			   //.AddRewrite("(.*)", "/$1", true);
			   // HomeApp.UseRewriter(rewrite);

			   HomeApp.UseDefaultFiles();

			   // //DefaultFilesOptions options = new DefaultFilesOptions();
			   // //options.DefaultFileNames.Clear();
			   // //options.DefaultFileNames.Add("/home1/index.html");
			   // //HomeApp.UseDefaultFiles(options);

			   HomeApp.UseStaticFiles(new StaticFileOptions()
			   {
				   FileProvider = new PhysicalFileProvider(
				  Path.Combine(env.ContentRootPath
						  , @"wwwroot\Home1")),
				   //RequestPath = new PathString("/home"),
			   });

			   //HomeApp.Run(async context => {
			   // Console.WriteLine("I am your life handler");
			   // await context.Response.WriteAsync("I am your life handler");
			   //});

			   HomeApp.UseEndpoints(endpoints =>
			   {
				   endpoints.MapFallbackToFile("/index.html");
			   });
		   });



		app.UseEndpoints(endpoints =>
		{
			
			endpoints.MapControllers();
			endpoints.MapFallbackToFile("/index.html");
		});
	}
}
