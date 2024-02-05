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
            this.labCrossThread_TestText.Text = "ũ�ν� ������ ������ ���ϴ�.";
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
                        = "ũ�ν� ������ ������ �� ���ϴ�.";
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
                    this.labCrossThread_TestText.Text = "����ȭ �Լ� - �ܺ� ������";
                });
            
        }).Start();
        
    }

    private void btnGlobal_This_Click(object sender, EventArgs e)
    {
        GlobalStatic.CrossThread_Winfom(
        this
        , () =>
        {
            this.labCrossThread_TestText.Text = "����ȭ �Լ� 1 - �ڱ� ������";
        });
    }
}
