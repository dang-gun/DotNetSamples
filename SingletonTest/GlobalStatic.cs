

using SingletonTest.Singletons;

namespace SingletonTest;

internal static class GlobalStatic
{
    /// <summary>
    /// 인덱스로 사용할 카운터
    /// </summary>
    internal static int IndexCount = 0;

    /// <summary>
    /// 프로그램 시작과 동시에 생성된다.
    /// </summary>
    internal static StaticNoSingleton NoSingleton = new StaticNoSingleton();
}
