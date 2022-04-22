using GameLoopProc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace GameLoopTest
{
	internal class MainGame : GameLoopInterface
	{
		public GameLoopProcInterface GameLoop;

		/// <summary>
		/// FPS 표시용 타이머
		/// </summary>
		private System.Timers.Timer timerFps;
		/// <summary>
		/// FPS 기록용 카운터
		/// </summary>
		private int FpsCount = 0;
			

		public MainGame()
		{
			//this.GameLoop = new GameLoopTickCount (this);
			//this.GameLoop = new GameLoopTimeSpan(this);
			this.GameLoop = new GameLoopStopwatch(this);
			this.GameLoop.FPS = 60;

			this.timerFps = new System.Timers.Timer();
			this.timerFps.Interval = 1000;
			this.timerFps.Elapsed += TimerFps_Elapsed;
		}

		private void TimerFps_Elapsed(object? sender, ElapsedEventArgs e)
		{
			Console.WriteLine(String.Format("FPS : {0}", this.FpsCount));
			this.FpsCount = 0;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public async Task Start()
		{
			this.timerFps.Start();

			await this.GameLoop.Start();
			Console.WriteLine("Game Start!!!");
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void Update()
		{
			++this.FpsCount;
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void Stop()
		{
			//throw new NotImplementedException();
			Console.WriteLine("Game Stop");
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		public void StopCompleted()
		{
			//throw new NotImplementedException();
		}

		
	}
}
