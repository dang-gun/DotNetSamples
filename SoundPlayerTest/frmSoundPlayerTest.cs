using System.Media;
using System.Runtime.InteropServices;
using System.Text;

namespace SoundPlayerTest
{
	public partial class frmSoundPlayerTest : Form
	{
		/// <summary>
		/// https://docs.microsoft.com/ko-kr/previous-versions//dd757161(v=vs.85)
		/// </summary>
		/// <param name="command"></param>
		/// <param name="buffer"></param>
		/// <param name="bufferSize"></param>
		/// <param name="hwndCallback"></param>
		/// <returns></returns>
		[DllImport("winmm.dll")]
		static extern Int32 mciSendString(
			string command
			, StringBuilder? buffer
			, int bufferSize
			, IntPtr hwndCallback);


		public frmSoundPlayerTest()
		{
			InitializeComponent();

			this._soundPlayer1 = new SoundPlayer();
			this._soundPlayer1.SoundLocation = @"SoundFiles\IsUse.wav";

			this._soundPlayer2 = new SoundPlayer();
			this._soundPlayer2.SoundLocation = @"SoundFiles\PutCardAgain.wav";

			mciSendString(@"open SoundFiles\IsUse.wav type waveaudio alias SoundMci1"
							, null, 0, IntPtr.Zero);
			mciSendString(@"open SoundFiles\PutCardAgain.wav type waveaudio alias SoundMci2"
							, null, 0, IntPtr.Zero);
		}

		#region Sound Play

		private SoundPlayer _soundPlayer1;
		private SoundPlayer _soundPlayer2;

		private void btnSoundPlay_One_Click(object sender, EventArgs e)
		{
			this._soundPlayer1.Play();
		}

		private void btnSoundPlay_Double_Click(object sender, EventArgs e)
		{
			this._soundPlayer1.Play();
			this._soundPlayer2.Play();
		}

		private void btnSoundPlay_Stop_Click(object sender, EventArgs e)
		{
			this._soundPlayer1.Stop();
		}

		#endregion

		#region mciSendString
		private void btnMciSend_One_Click(object sender, EventArgs e)
		{
			mciSendString(@"play SoundMci1", null, 0, IntPtr.Zero);
		}

		private void btnMciSend_Double_Click(object sender, EventArgs e)
		{
			mciSendString(@"play SoundMci1", null, 0, IntPtr.Zero);
			mciSendString(@"play SoundMci2", null, 0, IntPtr.Zero);
		}

		private void btnMciSend_DoubleRestart_Click(object sender, EventArgs e)
		{
			mciSendString(@"stop SoundMci1", null, 0, IntPtr.Zero);
			mciSendString("seek SoundMci1 to start", null, 0, IntPtr.Zero);
			mciSendString(@"stop SoundMci2", null, 0, IntPtr.Zero);
			mciSendString("seek SoundMci2 to start", null, 0, IntPtr.Zero);

			btnMciSend_Double_Click(sender, e);
		}

		private void btnMciSend_Stop_Click(object sender, EventArgs e)
		{
			mciSendString(@"stop SoundMci1", null, 0, IntPtr.Zero);
		}

		private void btnMciSend_Reset_Click(object sender, EventArgs e)
		{
			mciSendString("seek SoundMci1 to start", null, 0, IntPtr.Zero);
		}

		#endregion


	}
}