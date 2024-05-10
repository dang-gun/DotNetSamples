
namespace SingletonTest.Singletons;

/// <summary>
/// 싱글톤이 없는 경우
/// <para>호출할때마다 새개체가 생성된다.</para>
/// </summary>
/// <remarks>
/// .NET에서는 정적 초기화만 해도 동작하므로 이 예제는 억지를 부려서 만들어진 것이다.
/// </remarks>
public class NoSingleton
{
    /// <summary>
    /// 실제 개체
    /// </summary>
    private static NoSingleton? instance;

    /// <summary>
    /// 생성확인을 위한 인덱스(지워도됨)
    /// </summary>
    public int Index { get; private set; }

    private NoSingleton()
    {
        //생성확인을 위한 인덱스
        this.Index = ++GlobalStatic.IndexCount;

        //개체가 생성된 시간
        Console.WriteLine($"{GlobalStatic.LogTime()} NoSingleton 생성됨 : {this.Index}");
    }

    /// <summary>
    /// 개체 리턴
    /// </summary>
    public static NoSingleton Instance
    {
        get
        {
            //새 개체를 생성한다.
            instance = new NoSingleton();
            return instance;
        }
    }
}
