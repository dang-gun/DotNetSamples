using Newtonsoft.Json;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Text.Json.Serialization;
using Utility;
using Utility.OpenCvSharpAssist;

namespace OpenCvSharp4_Calibration;

public partial class Form1 : Form
{
    /// <summary>
    /// OpenCv_Capture 개체
    /// </summary>
    private OpenCv_Capture OCV_C = new OpenCv_Capture();

    public Form1()
    {
        InitializeComponent();

        this.tstxtCameraIndex.Text = "0";
        this.tstxtCameraSize_Width.Text = "4096";
        this.tstxtCameraSize_Height.Text = "2160";

    }

    #region 메뉴 > Config
    private void tsmiConfig_ViewOrientation_Click(object sender, EventArgs e)
    {
        if (this.splitMain.Orientation == Orientation.Vertical)
        {
            this.splitMain.Orientation = Orientation.Horizontal;
        }
        else
        {
            this.splitMain.Orientation = Orientation.Vertical;
        }
    }
    #endregion

    #region 메뉴 > Camera

    /// <summary>
    /// 카메라 세팅이 변경됐는지 여부
    /// </summary>
    private bool CameraSetChangeIs = true;

    private void tstxtCameraIndex_TextChanged(object sender, EventArgs e)
    {
        int nIndex = 0;
        if (false == Int32.TryParse(this.tstxtCameraIndex.Text, out nIndex))
        {//숫자로 바꿀 수 없다.

            //강제로 원래 가로크기로 변경
            this.tstxtCameraIndex.Text = this.OCV_C.CameraNumber.ToString();
        }
        else if (this.OCV_C.CameraNumber != nIndex)
        {//이전 값과 다르다.

            //세잍이 변경됐음을 알림
            this.CameraSetChangeIs = true;
        }
    }

    private void tstxtCameraSize_Width_TextChanged(object sender, EventArgs e)
    {
        int nWidth = 0;
        if (false == Int32.TryParse(this.tstxtCameraSize_Width.Text, out nWidth))
        {//숫자로 바꿀 수 없다.

            //강제로 원래 가로크기로 변경
            this.tstxtCameraSize_Width.Text = this.OCV_C.FrameWidth.ToString();
        }
        else if (this.OCV_C.FrameWidth != nWidth)
        {//이전 값과 다르다.

            //세잍이 변경됐음을 알림
            this.CameraSetChangeIs = true;
        }
    }

    private void tstxtCameraSize_Height_TextChanged(object sender, EventArgs e)
    {
        int nHeight = 0;
        if (false == Int32.TryParse(this.tstxtCameraSize_Height.Text, out nHeight))
        {//숫자로 바꿀 수 없다.

            //강제로 원래 세로크기로 변경
            this.tstxtCameraSize_Height.Text = this.OCV_C.FrameHeight.ToString();
        }
        else if (this.OCV_C.FrameHeight != nHeight)
        {//이전 값과 다르다.

            //세잍이 변경됐음을 알림
            this.CameraSetChangeIs = true;
        }
    }

    #endregion

    #region 메뉴 > Calibration
    private void tsmiCalibration_SelectFile_Click(object sender, EventArgs e)
    {
        bool bError = false;
        string sFilePath = string.Empty;

        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            //openFileDialog.InitialDirectory = "c:\\";
            //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {//파일 선택됨.

                sFilePath = openFileDialog.FileName;
            }
        }

        if (string.Empty != sFilePath)
        {
            try
            {
                this.OCV_C.Capture_LoadImage(sFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bError = true;
            }

        }


        if (false == bError)
        {
            this.ViewImage();
        }
    }

    private void tsmiCalibration_CameraCapture_Click(object sender, EventArgs e)
    {
        this.CameraCapture();
    }

    private void tsmiCalibration_RadialDistortionCheck_Click(object sender, EventArgs e)
    {
        int nChessBoardWidth = 0;
        if (false == Int32.TryParse(tstxtChessBoardWidth.Text, out nChessBoardWidth))
        {
            MessageBox.Show("Chess Board Width 입력이 잘못 되었습니다.");
            return;
        }

        int nChessBoardHeight = 0;
        if (false == Int32.TryParse(tstxtChessBoardHeight.Text, out nChessBoardHeight))
        {
            MessageBox.Show("Chess Board Height 입력이 잘못 되었습니다.");
            return;
        }

        try
        {
            //방사형 왜곡 계수 찾기
            this.OCV_C.RadialDistortionCheck(
                nChessBoardWidth
                , nChessBoardHeight);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void tsmiCalibration_RadialDistortionApply_Click(object sender, EventArgs e)
    {
        this.OCV_C.RadialDistortionApplyIs = true;
        this.OCV_C.CaptureImageLoad();

        this.ViewImage();
    }
    #endregion



    private void ViewImage()
    {
        this.pictureOriginal.Image = this.OCV_C.FrameMat.ToBitmap();
        try
        {
            this.pictureCalibrated.Image = this.OCV_C.FinalMat.ToBitmap();
        }
        catch { }

    }

    


    #region 파일 저장
    /// <summary>
    /// xml 파일로 저장시 기본 경로
    /// </summary>
    private readonly string CalibrationPath_Xml
        = Path.Combine("Configs", "Calibration.xml");
    /// <summary>
    /// yml 파일로 저장시 기본 경로
    /// </summary>
    private readonly string CalibrationPath_Yml
        = Path.Combine("Configs", "Calibration.yml");
    /// <summary>
    /// json 파일로 저장시 기본 경로
    /// </summary>
    private readonly string CalibrationPath_Json
        = Path.Combine("Configs", "Calibration.json");

    /// <summary>
    /// 보정 계수를 지정된 파일에 저장
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tsmiRadialDistortionFileSaveXml_Click(object sender, EventArgs e)
    {
        this.OCV_C.CalibrationData_FileSave(this.CalibrationPath_Xml);
    }

    private void tsmiRadialDistortionFileSaveYml_Click(object sender, EventArgs e)
    {
        this.OCV_C.CalibrationData_FileSave(this.CalibrationPath_Yml);
    }

    /// <summary>
    /// json 파일로 저장
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tsmiRadialDistortionFileSaveJson_Click(object sender, EventArgs e)
    {
        RadialDistortionDataModel radialDistortion
            = this.OCV_C.RadialDistortionData_ChangeModel();

        //string sJosn = JsonConvert.SerializeObject(radialDistortion);
        //File.WriteAllText(this.CalibrationPath_Json, sJosn);

        FileAssist newFA = new FileAssist();

        newFA.ObjectToJson(this.CalibrationPath_Json, radialDistortion);

    }
    #endregion

    #region 파일 불러오기
    /// <summary>
    /// 보정 계수를 지정된 파일에서 불러오기
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tsmiRadialDistortionFileLoadXml_Click(object sender, EventArgs e)
    {
        this.OCV_C.CalibrationData_FileLoad(this.CalibrationPath_Xml);
    }

    private void tsmiRadialDistortionFileLoadYml_Click(object sender, EventArgs e)
    {
        this.OCV_C.CalibrationData_FileLoad(this.CalibrationPath_Yml);
    }

    /// <summary>
    /// json 파일에서 읽기
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tsmiRadialDistortionFileLoadJson_Click(object sender, EventArgs e)
    {
        //string sJosn = File.ReadAllText(this.CalibrationPath_Json);
        //RadialDistortionDataModel? radialDistortion
        //    = JsonConvert.DeserializeObject<RadialDistortionDataModel>(sJosn);


        FileAssist newFA = new FileAssist();
        RadialDistortionDataModel? radialDistortion
            = newFA.JsonToModel<RadialDistortionDataModel>(this.CalibrationPath_Json);

        if (null != radialDistortion)
        {
            //읽어들인값 적용
            this.OCV_C.RadialDistortionData_ModelToMat(radialDistortion);
        }

    }



    #endregion

    private void tsmiCamera_Capture_Click(object sender, EventArgs e)
    {
        this.CameraCapture();
    }

    private void CameraCapture()
    {
        if(true == this.CameraSetChangeIs)
        {//카메라 정보가 변경되었다.

            //카메라 새로 생성
            this.OCV_C
                = new OpenCv_Capture(
                    Convert.ToInt32(this.tstxtCameraIndex.Text)
                    , Convert.ToInt32(this.tstxtCameraSize_Width.Text)
                    , Convert.ToInt32(this.tstxtCameraSize_Height.Text));

            this.CameraSetChangeIs = false;
        }

        //캡쳐
        this.OCV_C.Capture();
        //이미지 출력
        this.pictureOriginal.Image = this.OCV_C.FrameMat.ToBitmap();
    }
}
