using NAudio.Wave;
using System.Diagnostics;

namespace NAudioTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			for (int n = -1; n < WaveOut.DeviceCount; n++)
			{
				var caps = WaveOut.GetCapabilities(n);
				Debug.WriteLine($"{n}: {caps.ProductName}");
			}


			AudioFileReader audioFile1 = new AudioFileReader(@"C:\Users\Kim\Music\Routing_BGM_1.wav");
			AudioFileReader audioFile2 = new AudioFileReader(@"C:\Users\Kim\Music\Routing_BGM_6.wav");

			var outputDevice = new WaveOutEvent() ;
			var outputDevice2 = new WaveOutEvent();
			
			outputDevice.Init(audioFile1);
			outputDevice.Play();

			outputDevice2.Init(audioFile2);
			outputDevice2.Play();
		}
	}
}