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
        /// 이벤트 간격(ms)
        /// </summary>
        public long Interval 
		{
			get
			{
				return this._Interval_Ori;
			}
			set
			{
				this._Interval_Ori = value;
				//스톱워치는 정밀도가 높아 1s가 *10000000 이다.
				//리눅스에서는 *1000000000
				//ms로 바꾸기 위해 *0.001을 해준다.
				this.TickOneInterval = (this._Interval_Ori * (int)(Stopwatch.Frequency * 0.001));
			}
		}
        /// <summary>
        /// 이벤트 간격(ms) - 원본
        /// </summary>
        public long _Interval_Ori = 16;

		/// <summary>
		/// 한 틱의 간격
		/// </summary>
		/// <remarks>
		/// 기본값이 166666은 FPS로 60이다.
		/// </remarks>
		public long TickOneInterval { get; private set; } = 166666;

		/// <summary>
		/// 동작중인지 여부
		/// </summary>
		private bool _bLoop = false;

		public Timer()
		{

		}

		/// <summary>
		/// 타이머를 진행 시킨다.
		/// </summary>
		/// <returns></returns>
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
					if (nTicksNow > nLastTime + this.TickOneInterval)
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
