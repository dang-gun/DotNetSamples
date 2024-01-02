using System.Collections.Generic;
using System.Drawing;


namespace OpenCvSharp4_Calibration.Configs;

/// <summary>
/// 프로그램에 사용할 설정
/// </summary>
public class ProgramConfigModel
{
    /// <summary>
    /// 사용할 카메라 번호
    /// </summary>
    public int Camera_Number { get; set; } = 0;

    /// <summary>
    /// 카메라 - 캡쳐시 180도 회전 여부
    /// </summary>
    public bool Camera_Rotate180 { get; set; } = false;

    /// <summary>
    /// 카메라 보정에 사용될 체스판 크기
    /// <para>실제 칸수 -1을 해서 입력해야 한다.</para>
    /// </summary>
    //public Size Camera_ChessBoardSize { get; set; } = new Size(10, 7);
    public Size Camera_ChessBoardSize { get; set; } = new Size(22, 13);
}

