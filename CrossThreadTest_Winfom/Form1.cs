namespace CrossThreadTest_Winfom;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnCrossThread_Error_Click(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            this.labCrossThread_TestText.Text = "크로스 쓰래드 에러가 납니다.";
        }).Start();
    }


    private void btnNoneError_Click(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            this.Invoke(new Action(
                delegate ()
                {
                    this.labCrossThread_TestText.Text
                        = "크로스 쓰래드 에러가 안 납니다.";
                }));
        }).Start();
    }


    private void btnGlobal_Out_Click(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            GlobalStatic.CrossThread_Winfom(
                this
                , () => 
                {
                    this.labCrossThread_TestText.Text = "공통화 함수 - 외부 스레드";
                });
            
        }).Start();
        
    }

    private void btnGlobal_This_Click(object sender, EventArgs e)
    {
        GlobalStatic.CrossThread_Winfom(
        this
        , () =>
        {
            this.labCrossThread_TestText.Text = "공통화 함수 1 - 자기 스레드";
        });
    }
}
