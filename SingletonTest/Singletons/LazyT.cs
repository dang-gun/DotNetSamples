
namespace SingletonTest.Singletons;

/// <summary>
/// Lazy<T>를 이용한 싱글톤 구현
/// <para>.NET4 이상을 사용하는 경우 Lazy<T>를 사용할 수 있다.</para>
/// </summary>
public sealed class LazyT
{
    /// <summary>
    /// 실제 개체
    /// </summary>
    private static readonly Lazy<LazyT> lazy 
        = new Lazy<LazyT>(() => new LazyT());

    /// <summary>
    /// 생성확인을 위한 인덱스(지워도됨)
    /// </summary>
    public int Index { get; private set; }


    private LazyT()
    {
        //생성확인을 위한 인덱스
        this.Index = ++GlobalStatic.IndexCount;

        //개체가 생성된 시간
        Console.WriteLine($"{GlobalStatic.LogTime()} LazyT 생성됨 : {this.Index}");
    }

    /// <summary>
    /// 개체 리턴
    /// </summary>
    public static LazyT Instance 
    { 
        get 
        { 
            return lazy.Value; 
        } 
    }
}
