using System;

namespace ReleaseTestDll
{
	/// <summary>
	/// 릴리즈 테스트용 DLL
	/// </summary>
	public class ReleaseTest
	{

#if DEBUG
		/// <summary>
		/// 디버그용 DLL이 사용됨
		/// </summary>
		public static string TestString = "Debug Dll";
#else
		/// <summary>
		/// 릴리즈용 DLL이 사용됨
		/// </summary>
		public static string TestString = "Release Dll";
#endif

	}
}
