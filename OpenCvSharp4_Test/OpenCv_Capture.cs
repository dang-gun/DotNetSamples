using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCvSharp4_Test;

/// <summary>
/// OpenCv를 이용하여 캠에 접근/사용 하는 클래스
/// </summary>
internal class OpenCv_Capture: IDisposable
{
    /// <summary>
    /// 캡쳐에 사용될 비디오캡쳐 개체
    /// </summary>
    private VideoCapture? Cam;
    /// <summary>
    /// 이미지를 전달받을 mat 개체
    /// </summary>
    private Mat FrameMat = new Mat();

    /// <summary>
    /// 
    /// </summary>
    public OpenCv_Capture()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nCamNumber">사용할 카메라 번호</param>
    /// <param name="nFrameWidth">프레임 가로 크기</param>
    /// <param name="nFrameHeight">프레임 세로 크기</param>
    public OpenCv_Capture(
        int nCamNumber
        , int nFrameWidth
        , int nFrameHeight)
    {
        bool bSuccess 
            = this.CamSet(nCamNumber, nFrameWidth, nFrameHeight);

        if (false == bSuccess)
        {
            throw new Exception("카메라 초기화에 실패하였습니다.");
        }
    }

    /// <summary>
    /// 파괴자
    /// </summary>
    public void Dispose()
    {
        if (null != this.Cam)
        {
            this.Cam.Dispose();
        }

        this.FrameMat.Dispose();
    }

    /// <summary>
    /// 캠을 설정하고 초기화한다.
    /// </summary>
    /// <param name="nCamNumber">사용할 카메라 번호</param>
    /// <param name="nFrameWidth">프레임 가로 크기</param>
    /// <param name="nFrameHeight">프레임 세로 크기</param>
    /// <returns></returns>
    public bool CamSet(
        int nCamNumber
        , int nFrameWidth
        , int nFrameHeight)
    {
        bool bReturn = false;

        try
        {
            //지정된 번호의 카메라로 개체 생성
            this.Cam = new VideoCapture(nCamNumber);

            //사용할 프레임 크기 설정
            this.Cam.FrameWidth = nFrameWidth;
            this.Cam.FrameHeight = nFrameHeight;

            //사용할 fps 설정
            this.Cam.Fps = 30;

            bReturn = true;
        }
        catch
        {
            bReturn = false;
        }

        return bReturn;
    }

    /// <summary>
    /// 가지고 있는 VideoCapture개체에서 이미지를 캡쳐한다.
    /// </summary>
    /// <returns></returns>
    public Bitmap? Captuer()
    {
        Bitmap? bitmapReturn = null;

        // 0번 장비로 생성된 VideoCapture 객체에서 frame을 읽어옴
        if(null != this.Cam)
        {
            this.Cam.Read(this.FrameMat);
            try
            {
                // 읽어온 Mat 데이터를 Bitmap 데이터로 변경 후 컨트롤에 그려줌
                bitmapReturn = this.FrameMat.ToBitmap();
            }
            catch { }
        }
        

        return bitmapReturn;
    }
}
