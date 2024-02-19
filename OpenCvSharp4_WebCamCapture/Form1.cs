using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCvSharp4_WebCamCapture
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ĸ�Ŀ� ���� ����ĸ�� ��ü
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
            //������ ��ȣ�� ī�޶�� ��ü ����
            VideoCapture? cam = new VideoCapture(0);
            //���̷�Ʈ��(DirectShow)�� ����ϴ� ���
            //VideoCapture? cam = new VideoCapture(0, VideoCaptureAPIs.DSHOW);

            //������ ��ȣ�� ī�޶�� ��ü ����
            //https://answers.opencv.org/question/41964/cv_cap_prop_settings-working-on-opencvsharp-not-on-opencv/


            //���⼭ ������ �ϵ���� ������ ��ķ�� �����ϴ� ������ �Ǿ�� �Ѵ�.
            //�������� �ʴ� ������ ���������� ��� �������� �� �� ����.

            //����� fps ����
            cam.Fps = 30;

            //����� ������ ũ�� ����
            cam.FrameWidth = 1980;
            cam.FrameHeight = 1080;

            //cam.FrameWidth = 4096;
            //cam.FrameHeight = 2160;


            if (null != cam)
            {//ī�޶� ���������� �ʱ�ȭ �Ǿ���.

                //�ӽ� �̹��� ��ü ����
                Mat matTemp = new Mat();

                //������ ��񿡼� ĸ��
                cam.Read(matTemp);
                //���� ����
                this.pictureOutput.Image = matTemp.ToBitmap();
            }
        }

        private void btnCameraCapture_Click(object sender, EventArgs e)
        {
            //ī�޶� �ε���
            int nCamNumber = 0;
            int.TryParse(this.txtCameraIndex.Text, out nCamNumber);

            //������ ũ�� - ����
            int nFrameWidth = 0;
            int.TryParse(this.txtCameraSize_Width.Text, out nFrameWidth);

            //������ ũ�� - ����
            int nFrameHeight = 0;
            int.TryParse(this.txtCameraSize_Height.Text, out nFrameHeight);

            //������ ��ȣ�� ī�޶�� ��ü ����
            this.Cam = new VideoCapture(nCamNumber);
            //���̷�Ʈ��(DirectShow)�� ����ϴ� ���
            //https://answers.opencv.org/question/41964/cv_cap_prop_settings-working-on-opencvsharp-not-on-opencv/
            //this.Cam = new VideoCapture(nCamNumber, VideoCaptureAPIs.DSHOW);




            //���⼭ ������ �ϵ���� ������ ��ķ�� �����ϴ� ������ �Ǿ�� �Ѵ�.
            //�������� �ʴ� ������ ���������� ��� �������� �� �� ����.

            //����� fps ����
            this.Cam.Fps = 30;

            //����� ������ ũ�� ����
            this.Cam.FrameWidth = nFrameWidth;
            this.Cam.FrameHeight = nFrameHeight;


            if (null != this.Cam)
            {//ī�޶� ���������� �ʱ�ȭ �Ǿ���.

                //�ӽ� �̹��� ��ü ����
                Mat matTemp = new Mat();

                //������ ��񿡼� ĸ��
                this.Cam.Read(matTemp);
                //���� ����
                this.pictureOutput.Image = matTemp.ToBitmap();

            }
        }

    }
}
