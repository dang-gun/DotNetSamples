
using ConsoleWindowSetting;

namespace ConsoleWindowSettingTest;

internal class Program
{
	static void Main(string[] args)
	{

		ConsoleWindow.QuickEditMode(false);
		ConsoleWindow.F11Key(false);

		Console.WriteLine("------- Exit Agent ------");
		Console.WriteLine("------- 'R' 을 눌러 프로그램 종료 ------");

		ConsoleKeyInfo keyinfo;
		do
		{
			keyinfo = Console.ReadKey();
		} while (keyinfo.Key != ConsoleKey.R);
	}
}