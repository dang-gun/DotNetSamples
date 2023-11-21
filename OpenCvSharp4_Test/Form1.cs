namespace OpenCvSharp4_Test;

public partial class Form1 : Form
{
    private OpenCv_Capture ocvCapture;

    public Form1()
    {
        InitializeComponent();

        this.ocvCapture = new OpenCv_Capture(0, 3840, 2160);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.ocvCapture.Dispose();
    }

    private void btnCamCapture_Click(object sender, EventArgs e)
    {
        this.pictureView.Image
            = this.ocvCapture.Captuer();
    }

    
}