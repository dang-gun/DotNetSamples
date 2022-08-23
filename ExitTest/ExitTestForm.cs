using System.Diagnostics;

namespace ExitTest
{
	public partial class ExitTestForm : Form
	{
		/// <summary>
		/// 포그라운드 쓰래드 재생여부
		/// </summary>
		private bool _bForeground = true;
		
		public ExitTestForm()
		{
			InitializeComponent();
		}

		private void ExitTestForm_Load(object sender, EventArgs e)
		{
			Thread threadForeground 
				= new Thread(()=> 
				{
					while (true == this._bForeground)
					{
						Thread.Sleep(1000);
						Debug.WriteLine(String.Format("Foreground :{0}", DateTime.Now.ToString("HH:mm:ss")));
					};
				});
			//threadForeground.IsBackground = true;
			threadForeground.Start();
		}

		private void ExitTestForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Debug.WriteLine(String.Format("FormClosed :{0}", DateTime.Now.ToString("HH:mm:ss")));
		}

		private void btnForegroundEnd_Click(object sender, EventArgs e)
		{
			this._bForeground = false;
		}

		private void btnApplicationExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnEnvironmentExit_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void btnProcessKill_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}

		
	}
}