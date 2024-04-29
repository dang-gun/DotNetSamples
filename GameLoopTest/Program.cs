using DGU_ConsoleAssist;


namespace GameLoopTest
{
	internal class Program
	{
		public static MainGame MainGame;

		static void Main(string[] args)
		{
            Console.WriteLine("Hello, Dang Gun - .NET Samples");
            Console.WriteLine("☆☆☆ Game Loop Test ☆☆☆");

			int nSelectMenu = 0;

            ConsoleMenuAssist newCA = new ConsoleMenuAssist();
            newCA.WelcomeMessage = $"Select the test menu {Environment.NewLine}"
                + "--------------------------------------------";

            newCA.MenuList.Add(new MenuModel()
            {
                Index = 0,
                MatchString = "Stopwatch",
                TextFormat = "{0}. [{1}] Stopwatch base",
                Action = (MenuModel menuThis) =>
                {
                    nSelectMenu = 0;
                    Console.WriteLine($"selected 'Stopwatch'.");
                    return false;
                }
            });

            newCA.MenuList.Add(new MenuModel()
            {
                Index = 1,
                MatchString = "TickCount",
                TextFormat = "{0}. [{1}] TickCount base",
                Action = (MenuModel menuThis) =>
                {
                    nSelectMenu = 1;
                    Console.WriteLine($"selected 'TickCount'.");
                    return false;
                }
            });

            newCA.MenuList.Add(new MenuModel()
            {
                Index = 2,
                MatchString = "TimeSpan",
                TextFormat = "{0}. [{1}] TimeSpan base",
                Action = (MenuModel menuThis) =>
                {
                    nSelectMenu = 2;
                    Console.WriteLine($"selected 'TimeSpan'.");
                    return false;
                }
            });

            newCA.QuestionMessage = $"--------------------------------------------{Environment.NewLine}"
                + $"Select Command : ";

            //메뉴 표시
            newCA.ShowKeyWait(false);


            Console.WriteLine(" ");
            //메인 게임 개체를 만들고
            MainGame = new MainGame(nSelectMenu);

			//쓰레드를 대기한다.
			MainGame.Start().Wait();

			Console.ReadLine();
		}
	}
}
