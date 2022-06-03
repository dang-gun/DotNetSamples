using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 스탑워치를 이용한 타이머
/// </summary>
namespace StopwatchTimer
{

    public class Timer
    {
		#region 외부로 노출시킬 이벤트
		/// <summary>
		/// 외부에 에러를 알릴 이벤트
		/// </summary>
		/// <param name="nCode"></param>
		public delegate void ElapsedDelegate(object sender);
		/// <summary>
		/// 외부로 알릴 에러가 있으면 넣는다.
		/// </summary>
		public event ElapsedDelegate OnElapsed;
		private void OnElapsedCall()
		{
			if (null != OnElapsed)
			{
				this.OnElapsed(this);
			}
		}
		#endregion

		/// <summary>
		/// 이벤트 간격
		/// </summary>
		public int Interval 
		{
			get
			{
				return this._Interval_Ori;
			}
			set
			{
				this._Interval_Ori = value;
				//스톱워치는 정밀도가 높아 한 틱의 단위가 *10000 이다.
				this.FrameTick = (this._Interval_Ori * 10000) ;
			}
		}
		public int _Interval_Ori = 0;

		public int FrameTick { get; private set; } = 166666;

		/// <summary>
		/// 동작중인지 여부
		/// </summary>
		private bool _bLoop = false;

		public Timer()
		{

		}

		public async Task Start()
		{
			this._bLoop = true;

			long nLastTime = 0;

			Stopwatch sw = new Stopwatch();
			sw.Start();

			await Task.Run(() =>
			{
				while (true == this._bLoop)
				{
					//현제 틱
					long nTicksNow = sw.ElapsedTicks;

					//마지막 틱 + 프레임 만큼 시간이 지났는지 확인
					if (nTicksNow > nLastTime + this.FrameTick)
					{
						nLastTime = nTicksNow;
						//업데이트 알림
						this.OnElapsedCall();
					}
				}

				sw.Stop();
			});
		}

		public void Stop()
		{
			this._bLoop = false;
		}
	}

}
