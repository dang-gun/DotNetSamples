using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWindowSetting;


/// <summary>
/// https://stackoverflow.com/a/53391837/6725889
/// </summary>
public static class NativeFunctions
{
    /// <summary>
    /// https://docs.microsoft.com/ko-kr/windows/console/getstdhandle
    /// </summary>
    public enum StdHandle : int
    {
        /// <summary>
        /// 콘솔 입력 버퍼
        /// </summary>
        STD_INPUT_HANDLE = -10,
        /// <summary>
        /// 콘솔 화면 버퍼
        /// </summary>
        STD_OUTPUT_HANDLE = -11,
        /// <summary>
        /// 오류 디바이스
        /// </summary>
        STD_ERROR_HANDLE = -12,
    }

    /// <summary>
    /// https://docs.microsoft.com/ko-kr/windows/console/getstdhandle
    /// </summary>
    /// <param name="nStdHandle"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int nStdHandle); //returns Handle

    /// <summary>
    /// https://docs.microsoft.com/ko-kr/windows/console/setconsolemode
    /// </summary>
    public enum ConsoleMode : uint
    {
        ENABLE_ECHO_INPUT = 0x0004,
        ENABLE_EXTENDED_FLAGS = 0x0080,
        ENABLE_INSERT_MODE = 0x0020,
        ENABLE_LINE_INPUT = 0x0002,
        ENABLE_MOUSE_INPUT = 0x0010,
        /// <summary>
        /// 시스템 입력을 활성화 한다.
        /// </summary>
        /// <remarks>
        /// 'CTRL+C'나 'F11(전체 화면)'과 같은 시스템 키를 활성화 한다.<br />
        /// 이 기능이 활성화되면 예약된 시스템 키들은 콘솔로 키이벤트를 보내지 않는다.
        /// </remarks>
        ENABLE_PROCESSED_INPUT = 0x0001,
        /// <summary>
        /// 퀵 에디트 모드
        /// </summary>
        /// <remarks>
        /// 마우스를 이용하여 편집모드를 사용한다.<br />
        /// 단, 편집모드동안은 프로그램이 정지한다.(쓰래드가 멈춘다.)
        /// </remarks>
        ENABLE_QUICK_EDIT_MODE = 0x0040,
        ENABLE_WINDOW_INPUT = 0x0008,
        ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200,

        //screen buffer handle
        ENABLE_PROCESSED_OUTPUT = 0x0001,
        ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,
        ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,
        DISABLE_NEWLINE_AUTO_RETURN = 0x0008,
        ENABLE_LVB_GRID_WORLDWIDE = 0x0010
    }

    /// <summary>
    /// https://docs.microsoft.com/ko-kr/windows/console/getconsolemode
    /// </summary>
    /// <param name="hConsoleHandle"></param>
    /// <param name="lpMode"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
    /// <summary>
    /// https://docs.microsoft.com/ko-kr/windows/console/setconsolemode
    /// </summary>
    /// <param name="hConsoleHandle"></param>
    /// <param name="dwMode"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
}

/// <summary>
/// https://stackoverflow.com/a/53391837/6725889
/// </summary>
public static class ConsoleWindow
{
    /// <summary>
    /// 지정된 모드를 활성화 한다.
    /// </summary>
    /// <param name="typeConsoleMode"></param>
    public static void ConsoleModeEnable(NativeFunctions.ConsoleMode typeConsoleMode)
    {
        IntPtr consoleHandle = NativeFunctions.GetStdHandle((int)NativeFunctions.StdHandle.STD_INPUT_HANDLE);
        UInt32 consoleMode;
        NativeFunctions.GetConsoleMode(consoleHandle, out consoleMode);
        consoleMode |= ((uint)typeConsoleMode);

        consoleMode |= ((uint)NativeFunctions.ConsoleMode.ENABLE_EXTENDED_FLAGS);

        NativeFunctions.SetConsoleMode(consoleHandle, consoleMode);
    }

    /// <summary>
    /// 지정된 모드를 비활성화 한다.
    /// </summary>
    /// <param name="typeConsoleMode"></param>
    public static void ConsoleModeDisable(NativeFunctions.ConsoleMode typeConsoleMode)
    {
        IntPtr consoleHandle = NativeFunctions.GetStdHandle((int)NativeFunctions.StdHandle.STD_INPUT_HANDLE);
        UInt32 consoleMode;
        NativeFunctions.GetConsoleMode(consoleHandle, out consoleMode);
        consoleMode &= ~((uint)typeConsoleMode);

        consoleMode |= ((uint)NativeFunctions.ConsoleMode.ENABLE_EXTENDED_FLAGS);

        NativeFunctions.SetConsoleMode(consoleHandle, consoleMode);
    }

    /// <summary>
    /// QuickEdit lets the user select text in the console window with the mouse, to copy to the windows clipboard.
    /// But selecting text stops the console process (e.g. unzipping). This may not be always wanted.
    /// </summary>
    /// <param name="bEnable"></param>
    public static void QuickEditMode(bool bEnable)
    {
        if (bEnable)
        {
            ConsoleModeEnable(NativeFunctions.ConsoleMode.ENABLE_QUICK_EDIT_MODE);
        }
        else
        {
            ConsoleModeDisable(NativeFunctions.ConsoleMode.ENABLE_QUICK_EDIT_MODE);
        }
    }

    /// <summary>
    /// f11 block full screen transition
    /// </summary>
    /// <param name="bEnable"></param>
    public static void F11Key(bool bEnable)
    {
        if (bEnable)
        {
            ConsoleModeEnable(NativeFunctions.ConsoleMode.ENABLE_PROCESSED_INPUT);
        }
        else
        {
            ConsoleModeDisable(NativeFunctions.ConsoleMode.ENABLE_PROCESSED_INPUT);
        }
    }
}
