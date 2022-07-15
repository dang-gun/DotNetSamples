var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//3.0 api 라우트
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//기본 페이지
app.UseDefaultFiles();
//wwwroot
app.UseStaticFiles();


//3.0 api 라우트 끝점
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
