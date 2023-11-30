
namespace OpenCvSharp4_Test;



public partial class Form1 : Form
{
    private OpenCv_Capture ocvCapture;

    public Form1()
    {
        InitializeComponent();

        //this.ocvCapture = new OpenCv_Capture(0, 3264, 2448);
        //this.ocvCapture = new OpenCv_Capture(0, 4096, 2160);
        this.ocvCapture = new OpenCv_Capture();
    }

    /// <summary>
    /// 폼의 리사이즈가 끝날때 발생하는 이벤트
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
        this.pictureView.Size
            = new System.Drawing.Size(
                this.Width
                , this.Height - 24);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.ocvCapture.Dispose();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string sDir = "C:\\Users\\Kim\\Pictures\\Camera Roll\\WIN_20231122_10_20_26_Pro.jpg";
    }

    private void button2_Click(object sender, EventArgs e)
    {


    }

    private void button3_Click(object sender, EventArgs e)
    {

    }


    private void tsmiCamCapture_Click_1(object sender, EventArgs e)
    {
        this.pictureView.Image
            = this.ocvCapture.Capture();
    }


    private void tsmiCamera_DeviceList_ListRefresh_Click(object sender, EventArgs e)
    {

        //기존 리스트 제거
        while (2 < this.tsmiDeviceList.DropDownItems.Count)
        {
            //지울 대상을 찾고
            ToolStripItem item = this.tsmiDeviceList.DropDownItems[2];
            //지운다.
            this.tsmiDeviceList.DropDownItems.Remove(item);
        }

        //카메라 리스트 받기
        List<int> list = this.ocvCapture.CameraListCheck();
        foreach (int nItem in list)
        {
            //개체를 추가하고
            ToolStripMenuItem newTSI
                = (ToolStripMenuItem)this.tsmiDeviceList.DropDownItems.Add(nItem.ToString());


            newTSI.Click += NewTSI_Click;
        }
    }

    private void NewTSI_Click(object? sender, EventArgs e)
    {
        if (null != sender)
        {

            //모든 아이템의 체크를 끈다.
            for (int i = 2; i < this.tsmiDeviceList.DropDownItems.Count; ++i)
            {
                ToolStripMenuItem item
                    = (ToolStripMenuItem)this.tsmiDeviceList.DropDownItems[i];

                item.CheckState = CheckState.Unchecked;
            }//end for i

            //클릭한 아이템만 체크한다.
            ToolStripMenuItem thisTSI = (ToolStripMenuItem)sender;
            thisTSI.CheckState = CheckState.Checked;


            //가지고 있는 개체를 제거하고
            this.ocvCapture.CamRelease();
            //선택된 개체로 초기화
            this.ocvCapture.CamSet(Convert.ToInt32(thisTSI.Text), 4096, 2160);
        }
    }
}