using ReleaseTestDll;
using System;

namespace ReleaseDllTest_DllReference
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("DLL 메시지 : " + ReleaseTest.TestString);
			Console.ReadKey();
		}
	}
}
