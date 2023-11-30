using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCvSharp4_Test;

/// <summary>
/// OpenCv를 이용하여 캠에 접근/사용 하는 클래스
/// </summary>
internal class OpenCv_Capture: IDisposable
{
    /// <summary>
    /// 연결중인(혹은 연결예정인) 카메라 번호
    /// </summary>
    public int CameraNumber { get; set; } = -1;

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
    /// 사용 가능한 장치의 목록을 체크한다.
    /// </summary>
    /// <remarks>
    /// OpenCV에서는 장치 나열 기능이 없다
    /// <para>그래서 0번부터 열리는 것이 가능한 VideoCapture찾는 방식으로 구현한다.</para>
    /// </remarks>
    /// <param name="nForced_Check">강제로 검사할 개수(기본값 = 0)
    /// <para>시스템 상황에 따라 중간 숫자가 비어있을 수 있다.</para>
    /// <para>이런경우 이 숫자 만큼 강제로 추가 검사를 한다.</para>
    /// </param>
    /// <returns></returns>
    public List<int> CameraListCheck(int nForced_Check = 0)
    {
        List<int> listReturn = new List<int>();

        VideoCapture? temp;
        int device_counts = -1;
        int nForced_CheckCount = 0;

        bool bLoop = true;

        while (true == bLoop || nForced_CheckCount < nForced_Check)
        {
            ++device_counts;

            temp = new VideoCapture(device_counts);
            if (true == temp.IsOpened())
            {
                listReturn.Add(device_counts);
            }
            else
            {
                bLoop = false;
            }

            if(false == bLoop)
            {
                ++nForced_CheckCount;
            }

            temp.Release();
            temp = null;
        }

        if(0 < device_counts)
        {

        }

        return listReturn;
    }

    /// <summary>
    /// 가지고 있는 번호로 카메라를 설정하고 초기화 한다.
    /// </summary>
    /// <param name="nFrameWidth"></param>
    /// <param name="nFrameHeight"></param>
    /// <returns></returns>
    public bool CamSet(
        int nFrameWidth
        , int nFrameHeight)
    {
        return this.CamSet(this.CameraNumber, nFrameWidth, nFrameHeight);
    }


    /// <summary>
    /// 카메라를 설정하고 초기화한다.
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

        this.CameraNumber = nCamNumber;

        try
        {
            //지정된 번호의 카메라로 개체 생성
            //https://answers.opencv.org/question/41964/cv_cap_prop_settings-working-on-opencvsharp-not-on-opencv/
            this.Cam = new VideoCapture(nCamNumber, VideoCaptureAPIs.DSHOW);

            if(false == this.Cam.IsOpened())
            {
                bReturn = false;
            }
            else
            {
                //this.Cam = new VideoCapture(nCamNumber);


                this.Cam.Open(nCamNumber, VideoCaptureAPIs.DSHOW);
                //this.Cam.Open(nCamNumber);

                ////new cameraCapture
                //this.Cam.Set(
                //    VideoCaptureProperties.FourCC
                //    , OpenCvSharp.FourCC.MJPG);




                //사용할 fps 설정
                this.Cam.Fps = 30;

                //사용할 프레임 크기 설정
                this.Cam.FrameWidth = nFrameWidth;
                this.Cam.FrameHeight = nFrameHeight;

                bReturn = true;
            }

            
        }
        catch
        {
            bReturn = false;
        }

        return bReturn;
    }

    /// <summary>
    /// 지금 사용중인 카메라 개체를 제거한다.
    /// </summary>
    /// <returns></returns>
    public void CamRelease()
    {
        if(null != this.Cam)
        {
            this.Cam.Release();
            this.Cam = null;
        }
    }




    /// <summary>
    /// 가지고 있는 VideoCapture개체에서 이미지를 캡쳐한다.
    /// </summary>
    /// <returns></returns>
    public Bitmap? Capture()
    {
        Bitmap? bitmapReturn = null;

        if(null != this.Cam)
        {
            //지정된 장비에서 캡쳐
            this.Cam.Read(this.FrameMat);
            try
            {
                //읽어온 Mat 데이터를 Bitmap 데이터로 변환
                bitmapReturn = this.FrameMat.ToBitmap();
            }
            catch { }
        }
        

        return bitmapReturn;
    }
}
