

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

    /// <summary>
    /// 로그용 지금 시간을 리턴한다.
    /// </summary>
    /// <returns></returns>
    internal static string LogTime()
    {
        return $"[{DateTime.Now.ToString("HH:mm:ss:fff")}]";

    }
}
