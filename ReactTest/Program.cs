using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
	Args = args,
	// Look for static files in webroot
	WebRootPath = "webroot"
});



#region ConfigureServices
//API���� �Ľ�Į ���̽� �����ϱ�
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion


#region Configure
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{//���� ���������� ������ ���
	app.UseSwagger();
	app.UseSwaggerUI();
}

//3.0 api ���Ʈ
app.UseRouting();
//https�� �ڵ� ���𷺼�
app.UseHttpsRedirection();


//�⺻ ������
app.UseDefaultFiles();

//�� ��Ʈ
//app.UseStaticFiles();
if (true == app.Environment.IsDevelopment())
{//�����϶�
	app.UseStaticFiles(new StaticFileOptions
	{
		FileProvider = new PhysicalFileProvider(
		   Path.Combine(builder.Environment.ContentRootPath, @"wwwroot\dist")),
	});
}
else
{//�����϶�
	app.UseStaticFiles(new StaticFileOptions
	{
		FileProvider = new PhysicalFileProvider(
		   Path.Combine(builder.Environment.ContentRootPath, @"wwwroot\production")),
	});
}



app.MapControllers();

app.Run();
#endregion
