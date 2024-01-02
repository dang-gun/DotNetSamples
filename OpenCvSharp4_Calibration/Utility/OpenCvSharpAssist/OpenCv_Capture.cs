using System;
using System.Collections.Generic;

using OpenCvSharp;


namespace Utility.OpenCvSharpAssist;

/// <summary>
/// OpenCv를 이용하여 캠에 접근/사용 하는 클래스
/// </summary>
internal class OpenCv_Capture : IDisposable
{
    /// <summary>
    /// 방사형 개체
    /// </summary>
    private readonly string CameraMatrixName = "CameraMatrix";
    private readonly string CoefficientsName = "DistCoeffs";

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
    /// <para>아무런 보정없는 원본</para>
    /// </summary>
    public Mat FrameMat { get; private set; } = new Mat();
    /// <summary>
    /// 옵션에 따른 보정이 끝난 mat개체
    /// </summary>
    public Mat FinalMat { get; private set; } = new Mat();
    /// <summary>
    /// 옵션에 따른 보정이 끝나고 흑백 처리까지 된 mat개체
    /// </summary>
    public Mat? FinalMat_GrayScale { get; private set; }

    /// <summary>
    /// 카메라의 FrameWidth
    /// </summary>
    public int FrameWidth
    {
        get
        {
            int nReturn = 0;
            if (null != this.Cam )
            {
                nReturn = this.Cam.FrameWidth;
            }
            return nReturn;
        }
    }
    /// <summary>
    /// 카메라의 FrameHeight
    /// </summary>
    public int FrameHeight
    {
        get
        {
            int nReturn = 0;
            if (null != this.Cam)
            {
                nReturn = this.Cam.FrameHeight;
            }
            return nReturn;
        }
    }

    /// <summary>
    /// 카메라가 장비에 연결되었는지 여부
    /// </summary>
    public bool CameraConnectIs { get; private set; } = false;

    /// <summary>
    /// 캡쳐시 180도 회전 시킬지 여부
    /// </summary>
    public bool Rotate180Is { get; set; } = false;

    /// <summary>
    /// 흑백 이미지도 만들지 여부
    /// </summary>
    public bool GrayScaleIs { get; set; } = false;

    /// <summary>
    /// 방사형 왜곡 보정 적용할지 여부
    /// </summary>
    public bool RadialDistortionApplyIs { get; set; } = false;
    /// <summary>
    /// Camera Matrix
    /// <para>찾아낸 방사형 왜곡 계수</para>
    /// </summary>
    private Mat? CameraMatrixMat { get; set; }
    /// <summary>
    /// Distortion Coefficients
    /// <para>찾아낸 방사형 왜곡 계수</para>
    /// </summary>
    private Mat? CoefficientsMat { get; set; }


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

    #region 보정 계수 저장/복구 관련

    /// <summary>
    /// 보정 계수를 가지고 있는 MAT를 파일로 저장한다.
    /// </summary>
    public void CalibrationData_FileSave(string path)
    {
        if (null == this.CameraMatrixMat)
        {
            throw new Exception("방사 왜곡 계수를 읽을 수 없습니다 : Camera Matrix");
        }
        else if (null == this.CoefficientsMat)
        {
            throw new Exception("방사 왜곡 계수를 읽을 수 없습니다 : Coefficients");
        }

        //저장 시도
        this.CalibrationData_FileSave(
            path
            , this.CameraMatrixMat
            , this.CoefficientsMat);
    }
    /// <summary>
    /// 보정 계수를 가지고 있는 MAT를 파일로 저장한다.
    /// </summary>
    /// <remarks>
    /// 파일확장자가 .xml이면 xml 형식으로 저장된다.
    /// <para>파일확장자가 .yml이면 yml 형식으로 저장된다.</para>
    /// </remarks>
    /// <param name="path"></param>
    /// <param name="mat"></param>
    public void CalibrationData_FileSave(
        string path
        , Mat matCameraMatrix
        , Mat matCoefficients)
    {
        using (var fs = new FileStorage(path, FileStorage.Modes.Write))
        {
            fs.Write(this.CameraMatrixName, matCameraMatrix);
            fs.Write(this.CoefficientsName, matCoefficients);
        }
    }

    /// <summary>
    /// 보정 계수를 가지고 있는 파일을 읽어 이 개체에 저장한다.
    /// </summary>
    /// <remarks>
    /// 변경되는 변수
    /// <para>this.CameraMatrixMat</para>
    /// <para>this.CoefficientsMat</para>
    /// </remarks>
    /// <param name="path"></param>
    public void CalibrationData_FileLoad(string path)
    {
        Mat matTemp_CameraMatrix;
        Mat matTemp_Coefficients;

        //저장 시도
        this.CalibrationData_FileLoad(
            path
            , out matTemp_CameraMatrix
            , out matTemp_Coefficients);

        this.CameraMatrixMat = matTemp_CameraMatrix;
        this.CoefficientsMat = matTemp_Coefficients;
    }
    /// <summary>
    /// 보정 계수를 가지고 있는 파일을 읽어 MAT에 저장한다.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="matCameraMatrix"></param>
    /// <param name="matCoefficients"></param>
    public void CalibrationData_FileLoad(
        string path
        , out Mat matCameraMatrix
        , out Mat matCoefficients)
    {
        //행열 초기화
        matCameraMatrix = new Mat(3, 3, MatType.CV_64FC1);
        matCoefficients = new Mat(1, 5, MatType.CV_64FC1);

        using (var fs = new FileStorage(path, FileStorage.Modes.Read))
        {
            FileNode? temp;
            temp = fs[this.CameraMatrixName];
            if(null != temp)
            {
                matCameraMatrix = temp.ReadMat(matCameraMatrix);
            }

            temp = fs[this.CoefficientsName];
            if (null != temp)
            {
                matCoefficients = temp.ReadMat(matCoefficients);
            }
        }
    }

    /// <summary>
    /// 방사형 왜곡 계수를 가지고 있는 MAT를 RadialDistortionDataModel로 변환한다.
    /// </summary>
    /// <remarks>
    /// 가지고 있는 변수 사용
    /// </remarks>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public RadialDistortionDataModel RadialDistortionData_ChangeModel()
    {
        if (null == this.CameraMatrixMat)
        {
            throw new Exception("방사 왜곡 계수를 읽을 수 없습니다 : Camera Matrix");
        }
        else if (null == this.CoefficientsMat)
        {
            throw new Exception("방사 왜곡 계수를 읽을 수 없습니다 : Coefficients");
        }

        return RadialDistortionData_ChangeModel(
            this.CameraMatrixMat
            , this.CoefficientsMat);
    }
    /// <summary>
    /// 방사형 왜곡 계수를 가지고 있는 MAT를 RadialDistortionDataModel로 변환한다.
    /// </summary>
    /// <param name="matCameraMatrix"></param>
    /// <param name="matCoefficients"></param>
    /// <returns></returns>
    public RadialDistortionDataModel RadialDistortionData_ChangeModel(
        Mat matCameraMatrix
        , Mat matCoefficients)
    {

        RadialDistortionDataModel radialDistortion = new RadialDistortionDataModel();

        List<double> listCameraMatrix = new List<double>();
        listCameraMatrix.Add(matCameraMatrix.Get<double>(0, 0));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(0, 1));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(0, 2));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(1, 0));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(1, 1));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(1, 2));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(2, 0));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(2, 1));
        listCameraMatrix.Add(matCameraMatrix.Get<double>(2, 2));
        radialDistortion.CameraMatrixArray = listCameraMatrix.ToArray();


        List<double> listCoeffs = new List<double>();
        for (int i = 0; i < 5; ++i)
        {
            listCoeffs.Add(matCoefficients.Get<double>(0, i));
        }

        radialDistortion.CoefficientsArray = listCoeffs.ToArray();

        return radialDistortion;
    }

    /// <summary>
    /// RadialDistortionDataModel을 방사형 왜곡 계수를 가지고 있는 MAT로 변환한다.
    /// </summary>
    /// <param name="radialDistortion"></param>
    public void RadialDistortionData_ModelToMat(
        RadialDistortionDataModel radialDistortion)
    {
        Mat matTemp_CameraMatrix;
        Mat matTemp_Coefficients;

        this.RadialDistortionData_ModelToMat(
            radialDistortion
            , out matTemp_CameraMatrix
            , out matTemp_Coefficients);

        this.CameraMatrixMat = matTemp_CameraMatrix;
        this.CoefficientsMat = matTemp_Coefficients;
    }
    /// <summary>
    /// RadialDistortionDataModel을 방사형 왜곡 계수를 가지고 있는 MAT로 변환한다.
    /// </summary>
    /// <param name="radialDistortion"></param>
    /// <param name="matCameraMatrix"></param>
    /// <param name="matCoefficients"></param>
    public void RadialDistortionData_ModelToMat(
        RadialDistortionDataModel radialDistortion
        , out Mat matCameraMatrix
        , out Mat matCoefficients)
    {
        matCameraMatrix = new Mat(3, 3, MatType.CV_64FC1);

        matCameraMatrix.Set<double>(0, 0, radialDistortion.CameraMatrixArray[0]);
        matCameraMatrix.Set<double>(0, 1, radialDistortion.CameraMatrixArray[1]);
        matCameraMatrix.Set<double>(0, 2, radialDistortion.CameraMatrixArray[2]);

        matCameraMatrix.Set<double>(1, 0, radialDistortion.CameraMatrixArray[3]);
        matCameraMatrix.Set<double>(1, 1, radialDistortion.CameraMatrixArray[4]);
        matCameraMatrix.Set<double>(1, 2, radialDistortion.CameraMatrixArray[5]);

        matCameraMatrix.Set<double>(2, 0, radialDistortion.CameraMatrixArray[6]);
        matCameraMatrix.Set<double>(2, 1, radialDistortion.CameraMatrixArray[7]);
        matCameraMatrix.Set<double>(2, 2, radialDistortion.CameraMatrixArray[8]);



        matCoefficients = new Mat(1, 5, MatType.CV_64FC1);

        for (int i = 0; i < 5; ++i)
        {
            matCoefficients
                .Set<double>(0, i, radialDistortion.CoefficientsArray[i]);
        }
    }
    #endregion



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

            if (false == bLoop)
            {
                ++nForced_CheckCount;
            }

            temp.Release();
            temp = null;
        }

        if (0 < device_counts)
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

            if (false == this.Cam.IsOpened())
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

        //카메라 연결 여부를 알린다.
        this.CameraConnectIs = bReturn;

        return bReturn;
    }

    /// <summary>
    /// 지금 사용중인 카메라 개체를 제거한다.
    /// </summary>
    /// <returns></returns>
    public void CamRelease()
    {
        if (null != this.Cam)
        {
            this.Cam.Release();
            this.Cam = null;
        }
    }

    /// <summary>
    /// 지정한 경로의 파일을 읽어 원본 이미지로 지정한다.
    /// </summary>
    /// <param name="sFullPath"></param>
    /// <param name="bGrayScale"></param>
    /// <returns></returns>
    public void Capture_LoadImage(string sFullPath)
    {
        Mat matTemp = Cv2.ImRead(sFullPath, ImreadModes.Color);

        //원본 저장
        this.FrameMat = matTemp;
    }

    /// <summary>
    /// 가지고 있는 VideoCapture개체에서 이미지를 캡쳐하여 원본 이미지로 설정한다.
    /// </summary>
    /// <returns>옵션에 의해 보정된 이미지</returns>
    public void Capture()
    {
        // 0번 장비로 생성된 VideoCapture 객체에서 frame을 읽어옴
        if (null != this.Cam)
        {
            Mat matTemp = new Mat();

            //지정된 장비에서 캡쳐
            this.Cam.Read(matTemp);
            //원본 저장
            this.FrameMat = matTemp;
        }

    }

    /// <summary>
    /// FrameMat를 옵션에따라 보정하고 저장한다.
    /// </summary>
    public void CaptureImageLoad()
    {
        //원본 복사
        Mat matTemp = this.FrameMat.Clone();

        //방사형 왜곡 보정
        if (true == this.RadialDistortionApplyIs)
        {//방사형 왜곡 보정
            this.RadialDistortionApply(ref matTemp);
        }

        //180도 회전
        if (true == this.Rotate180Is)
        {
            this.Rotate180(ref matTemp);
        }


        //보정이 끝난 이미지 저장
        this.FinalMat = matTemp;

        //흑백 처리
        //흑백 옵션 사용여부에 따라 개체를 복제하여 FinalMat_GrayScale에 저장한다.
        if (true == this.GrayScaleIs)
        {
            Mat matTemp_GrayScale = matTemp.Clone();
            this.GrayScale(ref matTemp_GrayScale);
            this.FinalMat_GrayScale = matTemp_GrayScale;
        }
    }

    /// <summary>
    /// 카메라의 방사형 왜곡 계수를 저장한다.
    /// </summary>
    /// <remarks>
    /// 가급적 가공되지 않은 원본(회전 및 확대/축소 같은 작업)으로 작업하는걸 추천한다.
    /// <para>이미지가 가공되었으면 보정할때 가공된 내용을 염두하고 작업해야 한다.</para>
    /// </remarks>
    /// <param name="width">체스보드의 행수</param>
    /// <param name="height">체스보드의 열수</param>
    /// <returns></returns>
    public void RadialDistortionCheck(int width, int height)
    {
        // 체스보드의 행과 열의 수
        OpenCvSharp.Size patternSize = new OpenCvSharp.Size(width, height);
        float squareSize = 1.0f;  // 체스보드의 한 칸의 크기

        // 3D 포인트들을 저장할 리스트
        List<Mat> objectPoints = new List<Mat>();

        // 2D 포인트들을 저장할 리스트
        List<Mat> imagePoints = new List<Mat>();

        // 체스보드의 모든 코너들의 3D 위치를 계산
        Mat patternPoints = new Mat(patternSize.Height * patternSize.Width, 1, MatType.CV_32FC3);
        for (int i = 0; i < patternSize.Height; i++)
        {
            for (int j = 0; j < patternSize.Width; j++)
            {
                patternPoints.At<Vec3f>(i * patternSize.Width + j) = new Vec3f(j * squareSize, i * squareSize, 0);
            }
        }

        //마지막으로 캡쳐한 이미지를 사용한다.
        // 왜곡 감지에 사용할 체스보드 찍혀있는 카메라 이미지
        //Mat image = Cv2.ImRead("chessboard.jpg", ImreadModes.Grayscale);
        Mat image = new Mat();
        Cv2.CvtColor(this.FrameMat, image, ColorConversionCodes.BGR2GRAY);

        // 체스보드의 코너들을 찾음
        Point2f[] corners;
        bool found = Cv2.FindChessboardCorners(image, patternSize, out corners);

        if (found)
        {
            // 코너들의 위치를 더 정확하게 찾음
            Cv2.CornerSubPix(
                image
                , corners
                , new OpenCvSharp.Size(11, 11)
                , new OpenCvSharp.Size(-1, -1)
                , new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.MaxIter, 30, 0.1));

            // 3D 포인트들과 2D 포인트들을 추가
            imagePoints.Add(Mat.FromArray(corners));
            objectPoints.Add(patternPoints);
        }

        // 카메라 캘리브레이션을 수행
        Mat cameraMatrix = new Mat();
        Mat distCoeffs = new Mat();
        Mat[] rvecs, tvecs;
        double rms = Cv2.CalibrateCamera(objectPoints, imagePoints, image.Size(), cameraMatrix, distCoeffs, out rvecs, out tvecs);

        // 결과를 출력
        //System.Console.WriteLine("RMS: " + rms);
        //System.Console.WriteLine("Camera Matrix:\n" + cameraMatrix.Dump());
        //System.Console.WriteLine("Distortion Coefficients:\n" + distCoeffs.Dump());


        this.CameraMatrixMat = cameraMatrix;
        this.CoefficientsMat = distCoeffs;
    }



    /// <summary>
    /// 가지고 있는 방사형 계수를 가지고 matImage를 다시 만들어 준다.
    /// </summary>
    /// <param name="matImage"></param>
    public void RadialDistortionApply(ref Mat matImage)
    {
        if(null == this.CameraMatrixMat)
        {
            throw new Exception("방사 왜곡 계수를 읽을 수 없습니다 : Camera Matrix");
        }
        else if (null == this.CoefficientsMat)
        {
            throw new Exception("방사 왜곡 계수를 읽을 수 없습니다 : Coefficients");
        }

        //왜곡 보정된 이미지
        Mat dst = new Mat(matImage.Size(), matImage.Type());
        //Mat dst = new Mat();

        // 왜곡 보정을 수행합니다.
        Cv2.Undistort(matImage, dst, this.CameraMatrixMat, this.CoefficientsMat);
        matImage = dst;
    }

    /// <summary>
    /// 180도 회전
    /// </summary>
    /// <param name="matImage"></param>
    public void Rotate180(ref Mat matImage)
    {
        Cv2.Rotate(matImage, matImage, RotateFlags.Rotate180);
    }

    /// <summary>
    /// 흑백으로 변환
    /// </summary>
    /// <param name="matImage"></param>
    public void GrayScale(ref Mat matImage)
    {
        Cv2.CvtColor(matImage, matImage, ColorConversionCodes.BGR2GRAY);
    }
}
