
namespace CrossThreadTest_Winfom;

/// <summary>
/// 프로그램 전역 변수
/// </summary>
public static class GlobalStatic
{
    /// <summary>
    /// 크로스 스레드 체크를 하고 상황에 맞게 처리한다.
    /// </summary>
    /// <param name="controlThis"></param>
    /// <param name="action"></param>
    public static void CrossThread_Winfom(Control controlThis, Action action)
    {
        if (true == controlThis.InvokeRequired)
        {//다른 쓰래드다.
            controlThis.Invoke(new Action(
                delegate ()
                {
                    action();
                }));
        }
        else
        {//같은 쓰래드다.
            action();
        }
    }
}
