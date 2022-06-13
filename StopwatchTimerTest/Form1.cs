namespace StopwatchTimerTest
{
	public partial class Form1 : Form
	{
		

		/// <summary>
		/// 10�ʵ��� Ÿ�̸�
		/// </summary>
		private System.Timers.Timer _timer10Sec;

		/// <summary>
		/// 0.1�� ���� Ÿ�̸�
		/// </summary>
		private System.Timers.Timer _timer01Sec;
		/// <summary>
		/// �����ġ Ÿ�̸�
		/// </summary>
		private StopwatchTimer.Timer stopwatchTimer;

		/// <summary>
		/// ������ ����
		/// </summary>
		private bool _bProceeding = false;

		public Form1()
		{
			InitializeComponent();

			this._timer10Sec = new System.Timers.Timer();
			this._timer10Sec.Elapsed += _timer10Sec_Elapsed;

			this._timer01Sec = new System.Timers.Timer();
			this._timer01Sec.Interval = 10;
			this._timer01Sec.Elapsed += _timer01Sec_Elapsed;

			this.stopwatchTimer = new StopwatchTimer.Timer();
			this.stopwatchTimer.Interval = 10;
			this.stopwatchTimer.OnElapsed += StopwatchTimer_OnElapsed;
		}

		

		private void _timer10Sec_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
		{
			//�ٸ�Ÿ�̸� ��� ����
			this._timer01Sec.Stop();
			this.stopwatchTimer.Stop();

			this.Invoke(new Action(delegate ()
			{
				this.btn10Sec.Enabled = true;
				this.btn30Sec.Enabled = true;
			}));
		}

		/// <summary>
		/// 0.1�� Ÿ�̸� ī��Ʈ
		/// </summary>
		private int _nTimer01Sec_Count = 0;
		private void _timer01Sec_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
		{
			this.Invoke(new Action(delegate ()
			{
				++this._nTimer01Sec_Count;
				this.labTimer.Text = this._nTimer01Sec_Count.ToString();
			}));
			
		}

		/// <summary>
		/// �����ġ Ÿ�̸� ī��Ʈ
		/// </summary>
		private int _nStopwatchTimer_Count = 0;
		private void StopwatchTimer_OnElapsed(object sender)
		{
			
			this.Invoke(new Action(delegate ()
			{
				++this._nStopwatchTimer_Count;
				this.labStopwatch.Text = this._nStopwatchTimer_Count.ToString();
			}));

		}

		private void btnIntervalApply_Click(object sender, EventArgs e)
		{
			int nInterval = Convert.ToInt32(txtInterval.Text);

			this._timer01Sec.Interval = nInterval;
			this.stopwatchTimer.Interval = nInterval;
		}

		private async void btn10Sec_Click(object sender, EventArgs e)
		{
			this.btn10Sec.Enabled = false;
			this.btn30Sec.Enabled = false;
			this._timer10Sec.Interval = 10 * 1000;

			this._nTimer01Sec_Count = 0;
			this._nStopwatchTimer_Count = 0;

			//Ÿ�̸� ��� ����
			this._timer10Sec.Start();
			this._timer01Sec.Start();
			await this.stopwatchTimer.Start();
		}

		private async void btn30Sec_Click(object sender, EventArgs e)
		{
			this.btn10Sec.Enabled = false;
			this.btn30Sec.Enabled = false;
			this._timer10Sec.Interval = 30 * 1000;

			this._nTimer01Sec_Count = 0;
			this._nStopwatchTimer_Count = 0;

			//Ÿ�̸� ��� ����
			this._timer10Sec.Start();
			this._timer01Sec.Start();
			await this.stopwatchTimer.Start();
		}

		
	}
}