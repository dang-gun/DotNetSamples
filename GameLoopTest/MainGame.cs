﻿using GameLoopProc;
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
			
		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeLoop"></param>
		public MainGame(int typeLoop)
		{
			switch(typeLoop)
			{
				case 1://Environment.TickCount 기반
                    this.GameLoop = new GameLoopTickCount(this);
                    break;

				case 2://TimeSpan 기반
                    this.GameLoop = new GameLoopTimeSpan(this);
                    break;

				default://Stopwatch기반 
                    this.GameLoop = new GameLoopStopwatch(this);
                    break;
			}

            this.GameLoop.FPS = 60;
            //this.GameLoop.FPS = 30;

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
