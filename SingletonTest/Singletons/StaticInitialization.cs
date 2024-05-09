
namespace SingletonTest.Singletons;

/// <summary>
/// 정적 초기화
/// <para>C++의 정적변수 초기화 순서 문제로인한 회피코드를 제거한 코드</para>
/// </summary>
/// <remarks>
/// https://learn.microsoft.com/ko-kr/previous-versions/msp-n-p/ff650316(v=pandp.10)?redirectedfrom=MSDN#static-initialization
/// <para>《디자인 패턴》[Gamma95]방식은 C++에서 정적변수 초기화 순서로 인한 회피코드가 포함되어 있다.<br />
/// .NET에서는 이 문제가 없으므로 회피코드를 제거하고 바로 정적 초기화를 해도된다.</para>
/// <para>싱글톤 클래스를 상속받으면 디자인 위반 가능성이 있으므로 sealed로 상속을 막는다.</para>
/// </remarks>
public sealed class StaticInitialization
{
    /// <summary>
    /// 실제 개체
    /// </summary>
    /// <remarks>
    /// 싱글톤은 개체가 한번만 생성되므로 readonly로 선언하여 컴파일러의 성능을 향상시킬 '수'도 있다.
    /// </remarks>
    private static readonly StaticInitialization instance = new StaticInitialization();


    /// <summary>
    /// 생성확인을 위한 인덱스(지워도됨)
    /// </summary>
    public int Index { get; private set; }

    private StaticInitialization() 
    {
        //생성확인을 위한 인덱스
        this.Index = ++GlobalStatic.IndexCount;
    }

    /// <summary>
    /// 개체 리턴
    /// </summary>
    public static StaticInitialization Instance
    {
        get
        {
            return instance;
        }
    }
}
