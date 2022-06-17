
using ConsoleModeSetting;

namespace ConsoleModeSettingTest;

internal class Program
{
	static void Main(string[] args)
	{

		ConsoleWindow.QuickEditMode(false);
		ConsoleWindow.F11Key(false);

		for (int i = 0; i < 1000000; ++i)
		{
			Console.WriteLine("Count : " + i);
			Thread.Sleep(500);

			Console.Clear();
		}

		Console.WriteLine("------- Exit Agent ------");
		Console.WriteLine("------- 'R' 을 눌러 프로그램 종료 ------");

		ConsoleKeyInfo keyinfo;
		do
		{
			keyinfo = Console.ReadKey();
		} while (keyinfo.Key != ConsoleKey.R);
	}
}