
namespace SingletonTest.Singletons;

/// <summary>
/// 《디자인 패턴》[Gamma95]에서 제시된 싱글톤을 C#에 맞게 구현한 클래스
/// </summary>
/// <remarks>
/// https://learn.microsoft.com/ko-kr/previous-versions/msp-n-p/ff650316(v=pandp.10)?redirectedfrom=MSDN#singleton
/// </remarks>
public class Gamma95
{
    /// <summary>
    /// 실제 개체
    /// </summary>
    private static Gamma95? instance;

    /// <summary>
    /// 생성확인을 위한 인덱스(지워도됨)
    /// </summary>
    public int Index { get; private set; }

    private Gamma95()
    {
        //생성확인을 위한 인덱스
        this.Index = ++GlobalStatic.IndexCount;

        //개체가 생성된 시간
        Console.WriteLine($"{GlobalStatic.LogTime()} Gamma95 생성됨 : {this.Index}");
    }

    /// <summary>
    /// 개체 리턴
    /// </summary>
    public static Gamma95 Instance
    {
        get
        {
            if (instance == null)
            {//이미 생성된 개체가 없다.

                //새 개체를 생성한다.
                instance = new Gamma95();
            }
            return instance;
        }
    }
}
