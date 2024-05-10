
namespace SingletonTest.Singletons;

/// <summary>
/// 멀티스레드 상황에서 사용하는 싱글톤
/// <para>여러 스레드에서 한번에 개체에 접근할때도 1개의 개체를 보장하기위한 구현</para>
/// </summary>
/// <remarks>
/// https://learn.microsoft.com/ko-kr/previous-versions/msp-n-p/ff650316(v=pandp.10)?redirectedfrom=MSDN#multithreaded-singleton
/// <para>멀티스레드 상황에서 싱글톤을 호출하는경우 개체가 생성중일때
/// 다른 스레드에서 싱글톤 개체에 접근하려고 하는 경우가 있다.<br />
/// 이 경우 2개의 개체가 생성될 가능성이 있다.(특히 '공용 언어 런타임'를 사용하지 않는 경우)<br />
/// 이런 경우를 막기위한 구현이다.</para>
/// </remarks>
public sealed class MultithreadedSingleton
{
    /// <summary>
    /// 실제 개체
    /// </summary>
    private static volatile MultithreadedSingleton? instance;
    /// <summary>
    /// 단일 스레드 잠금을 위한 개체
    /// </summary>
    private static object syncRoot = new Object();

    /// <summary>
    /// 생성확인을 위한 인덱스(지워도됨)
    /// </summary>
    public int Index { get; private set; }

    private MultithreadedSingleton() 
    {
        //생성확인을 위한 인덱스
        this.Index = ++GlobalStatic.IndexCount;

        //개체가 생성된 시간
        Console.WriteLine($"{GlobalStatic.LogTime()} MultithreadedSingleton 생성됨 : {this.Index}");
    }

    /// <summary>
    /// 개체 리턴
    /// </summary>
    public static MultithreadedSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {//스레드를 잠금

                    //개체를 확인하고 생성하는 동안
                    //다른 스레드는 인스턴스 사용을 대기하게 된다.

                    if (instance == null)
                    {//이미 생성된 개체가 없다.

                        //새 개체를 생성한다.
                        instance = new MultithreadedSingleton();
                    }
                        
                }
            }

            return instance;
        }
    }
}
