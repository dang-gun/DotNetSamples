using System.Windows.Controls;

namespace AnimationPage;

internal class GlobalStatic
{
    /// <summary>
    /// 크로스 스레드 체크를 하고 상황에 맞게 처리한다.
    /// </summary>
    /// <param name="controlThis"></param>
    /// <param name="action"></param>
    public static void CrossThread_WPF(
        Control controlThis
        , Action action)
    {
        if (false == controlThis.Dispatcher.CheckAccess())
        {//다른 쓰래드다.
            controlThis.Dispatcher.BeginInvoke(new Action(
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
