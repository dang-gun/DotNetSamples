using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameLoopProc
{
	/// <summary>
	/// https://gamedev.stackexchange.com/questions/150287/proper-use-of-async-await-and-task-delay-for-a-game-loop
	/// https://gafferongames.com/post/fix_your_timestep/
	/// </summary>
	public class GameLoopTimeSpan : GameLoopProcInterface
	{
		/// <summary>
		/// 루프가 진행중인지 여부
		/// </summary>
		public bool LoopIs { get; set; }

		/// <summary>
		/// 초당 최대 프레임 수
		/// <para>1초에 몇번 update가 호출되는지 값이다.<br />
		/// 이 값은 최대치이고 컴퓨터의 상태에 따라 이값보다 낮게 동작 할수 있다.</para>
		/// </summary>
		public int FPS
		{
			get
			{
				return this.m_FPS;
			}

			set
			{
				this.m_FPS = value;
				this.FrameTick = TimeSpan.FromSeconds(1.0 / this.m_FPS);
			}
		}
		/// <summary>
		/// 초당 최대 프레임 수(원본)
		/// </summary>
		private int m_FPS = 60;

		/// <summary>
		/// 한번 Update를 호출하는 데 필요한 최소 시간(ms)
		/// <para>루프가 최소 이 시간 안에는 발생하지 않는다.<br />
		/// 컴퓨터의 상황에 따라 </para>
		/// </summary>
		public TimeSpan FrameTick { get; private set; } = TimeSpan.FromSeconds(0.0166666);

		/// <summary>
		/// GameLoop의 동작에 사용될 개체
		/// </summary>
		public GameLoopInterface TargetObject { get; protected set; }


		System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();



        /// <summary>
        /// TimeSpan기반 타임 루프
        /// </summary>
        /// <param name="objTarget">
        /// GameLoop의 동작에 사용될 개체<br />
        /// GameLoopInterface를 가지고 있어야 한다.
        /// </param>
        public GameLoopTimeSpan(GameLoopInterface objTarget)
		{
			this.TargetObject = objTarget;


		}

		/// <summary>
		/// 루프를 시작한다.
		/// </summary>
		public async Task Start()
		{
			this.LoopIs = true;


			sw.Start();
			var last = sw.Elapsed;
			var update_time = new TimeSpan(0);

			await Task.Run(() =>
			{
				while (true == this.LoopIs)
				{
					var delta = sw.Elapsed - last;
					last += delta;
					update_time += delta;

					Debug.WriteLine(string.Format("Now1 {0}, {1} "
									, update_time
									, this.FrameTick));

					while (update_time > this.FrameTick)
					{
						Debug.WriteLine(string.Format("Now2 {0}, {1} "
									, update_time
									, this.FrameTick));

						update_time -= this.FrameTick;
						//업데이트 알림
						this.TargetObject.Update();
					}
					
					// On some systems, this returns in 1 millisecond
					// on others, it may return in much higher.
					// If so, you should just comment this out, and let the main loop
					// spin to wait out the timer.
					System.Threading.Thread.Sleep(1);
				}

				//종료를 알림
				this.TargetObject.StopCompleted();
			});
		}


		/// <summary>
		/// 루프를 정지시킨다.
		/// 이미 진행된 루프는 계속 진행이 되기 때문에 정지를 시켜도 Update가 올수 있다.<br />
		/// 정확한 종료 시점은 StopCompleted로 확인해야 한다.
		/// </summary>
		public void Stop()
		{
			this.LoopIs = false;
		}

	}
}
