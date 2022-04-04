using Microsoft.Extensions.Options;

namespace WebApi_JwtAuthTest
{
	public class TestMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly Client _appSettings;

        public TestMiddleware(RequestDelegate next
            , IOptions<Client> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(
        HttpContext context)
        {
            
            await _next(context);
        }
    }
}
