using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.OpenCvSharpAssist;

/// <summary>
/// 방사 왜곡 계수 데이터 모델
/// </summary>
public class RadialDistortionDataModel
{
    /// <summary>
    /// Camera Matrix
    /// </summary>
    public double[] CameraMatrixArray { get; set; } = new double[0];

    /// <summary>
    /// Distortion Coefficients
    /// </summary>
    public double[] CoefficientsArray { get; set; } = new double[0];
}
