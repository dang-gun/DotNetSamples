using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MauiAppTest
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.UseMauiCompatibility()
				.ConfigureMauiHandlers(x =>
				{
#if ANDROID
    x.AddHandler<WebView, Platforms.Android.Controls.AndroidWebViewHandler>();
#endif
				});

			return builder.Build();
		}
	}
}