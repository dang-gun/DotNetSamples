
namespace SingletonTest.Singletons;

/// <summary>
/// 싱글톤 없이 정적 변수로 사용하기위한 예제 클래스
/// </summary>
public class StaticNoSingleton
{
    /// <summary>
    /// 생성확인을 위한 인덱스(지워도됨)
    /// </summary>
    public int Index { get; private set; }

    public StaticNoSingleton()
    {
        //생성확인을 위한 인덱스
        this.Index = ++GlobalStatic.IndexCount;
    }
}
