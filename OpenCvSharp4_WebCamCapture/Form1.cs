using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCvSharp4_WebCamCapture
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 캡쳐에 사용될 비디오캡쳐 개체
        /// </summary>
        private VideoCapture? Cam;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.pictureOutput.Size
                = new System.Drawing.Size(
                    this.Width - 40
                    , this.Height - 166);
        }

        private void btnCameraCapture_1TimeUse_Click(object sender, EventArgs e)
        {
            //지정된 번호의 카메라로 개체 생성
            VideoCapture? cam = new VideoCapture(0);
            //다이렉트쇼(DirectShow)를 사용하는 경우
            //VideoCapture? cam = new VideoCapture(0, VideoCaptureAPIs.DSHOW);

            //지정된 번호의 카메라로 개체 생성
            //https://answers.opencv.org/question/41964/cv_cap_prop_settings-working-on-opencvsharp-not-on-opencv/


            //여기서 수정된 하드웨어 설정은 웹캠이 지원하는 범위가 되어야 한다.
            //지원하지 않는 범위를 설정했을때 어떻게 동작할지 알 수 없다.

            //사용할 fps 설정
            cam.Fps = 30;

            //사용할 프레임 크기 설정
            cam.FrameWidth = 1980;
            cam.FrameHeight = 1080;

            //cam.FrameWidth = 4096;
            //cam.FrameHeight = 2160;


            if (null != cam)
            {//카메라가 정상적으로 초기화 되었다.

                //임시 이미지 개체 생성
                Mat matTemp = new Mat();

                //지정된 장비에서 캡쳐
                cam.Read(matTemp);
                //원본 저장
                this.pictureOutput.Image = matTemp.ToBitmap();
            }
        }

        private void btnCameraCapture_Click(object sender, EventArgs e)
        {
            //카메라 인덱스
            int nCamNumber = 0;
            int.TryParse(this.txtCameraIndex.Text, out nCamNumber);

            //프레임 크기 - 가로
            int nFrameWidth = 0;
            int.TryParse(this.txtCameraSize_Width.Text, out nFrameWidth);

            //프레임 크기 - 세로
            int nFrameHeight = 0;
            int.TryParse(this.txtCameraSize_Height.Text, out nFrameHeight);

            //지정된 번호의 카메라로 개체 생성
            this.Cam = new VideoCapture(nCamNumber);
            //다이렉트쇼(DirectShow)를 사용하는 경우
            //https://answers.opencv.org/question/41964/cv_cap_prop_settings-working-on-opencvsharp-not-on-opencv/
            //this.Cam = new VideoCapture(nCamNumber, VideoCaptureAPIs.DSHOW);




            //여기서 수정된 하드웨어 설정은 웹캠이 지원하는 범위가 되어야 한다.
            //지원하지 않는 범위를 설정했을때 어떻게 동작할지 알 수 없다.

            //사용할 fps 설정
            this.Cam.Fps = 30;

            //사용할 프레임 크기 설정
            this.Cam.FrameWidth = nFrameWidth;
            this.Cam.FrameHeight = nFrameHeight;


            if (null != this.Cam)
            {//카메라가 정상적으로 초기화 되었다.

                //임시 이미지 개체 생성
                Mat matTemp = new Mat();

                //지정된 장비에서 캡쳐
                this.Cam.Read(matTemp);
                //원본 저장
                this.pictureOutput.Image = matTemp.ToBitmap();

            }
        }

    }
}
