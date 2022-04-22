using GameLoopProc;
using System;

namespace GameLoopTest
{
	internal class Program
	{
		public static MainGame MainGame;

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			

			//메인 게임 개체를 만들고
			MainGame = new MainGame();

			//쓰레드를 대기한다.
			MainGame.Start().Wait();

			Console.ReadLine();
		}
	}
}
