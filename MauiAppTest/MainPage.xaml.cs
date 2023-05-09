namespace MauiAppTest;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();

		//this.webviewMain.Source = "https://learn.microsoft.com/dotnet/maui";
		this.webviewMain.Source = "http://hotech.co.kr/files/Download.html";
		//this.webviewMain.SetDownloadListener(new CustomDownloadListener());

		//HybridWebView hybridWebView = new HybridWebView();
		//hybridWebView
	}

}
