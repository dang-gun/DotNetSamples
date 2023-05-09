using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using MauiAppTest;
using Microsoft.Maui.Controls.Compatibility;

using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Handlers;
using System.Threading.Tasks;

//[assembly: ExportRenderer(typeof(Microsoft.Maui.Controls.WebView), typeof(CustomWebViewRenderer))]
namespace Platforms.Android.Controls;

public class AndroidWebViewHandler : WebViewHandler
{
	protected override void ConnectHandler(global::Android.Webkit.WebView platformView)
	{
		platformView.Settings.SetSupportMultipleWindows(false);
		platformView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
		platformView.SetDownloadListener(new CustomDownloadListener());

		platformView.Settings.JavaScriptEnabled = true;

		platformView.Download += PlatformView_Download;
		base.ConnectHandler(platformView);
	}

	private void PlatformView_Download(
		object sender
		, global::Android.Webkit.DownloadEventArgs e)
	{
		Console.WriteLine("다운로드 시작 : " + e.Url);

		DownloadManager.Request request 
			= new DownloadManager.Request(Android.Net.Uri.Empty);
		request.AllowScanningByMediaScanner();
		request.SetNotificationVisibility(DownloadVisibility.VisibleNotifyCompleted);

	}
}

public class CustomDownloadListener : Java.Lang.Object, IDownloadListener
{
	public void OnDownloadStart(
		string url
		, string userAgent
		, string contentDisposition
		, string mimetype
		, long contentLength)
	{
		Console.WriteLine("다운로드 핸들러 : " + url);
		try
		{
			//Uri aa = new Uri(url);


			//DownloadManager.Request request 
			//	= new DownloadManager.Request(aa);
			//request.AllowScanningByMediaScanner();
			//request.SetNotificationVisibility(DownloadVisibility.VisibleNotifyCompleted);

			//// if this path is not create, we can create it.  
			//string thmblibrary = FileSystem.AppDataDirectory + "/download";
			//if (!Directory.Exists(thmblibrary))
			//	Directory.CreateDirectory(thmblibrary);

			//request.SetDestinationInExternalFilesDir(Android.App.Application.Context, FileSystem.AppDataDirectory, "download");
			//DownloadManager dm = (DownloadManager)Android.App.Application.Context.GetSystemService(Android.App.Application.DownloadService);
			//dm.Enqueue(request);

		}
		catch (Exception)
		{
			throw;
		}

	}
}