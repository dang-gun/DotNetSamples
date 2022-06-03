namespace StopwatchTimerTest
{
	public partial class Form1 : Form
	{
		private StopwatchTimer.Timer stopwatchTimer;

		private int nCount = 0;

		public Form1()
		{
			InitializeComponent();

			this.stopwatchTimer = new StopwatchTimer.Timer();
			this.stopwatchTimer.Interval = 1000;
			this.stopwatchTimer.OnElapsed += StopwatchTimer_OnElapsed;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			await this.stopwatchTimer.Start();

		}

		private void StopwatchTimer_OnElapsed(object sender)
		{
			this.Invoke(new Action(delegate () 
			{
				this.Text = (++nCount).ToString();
			}));  

		}
	}
}