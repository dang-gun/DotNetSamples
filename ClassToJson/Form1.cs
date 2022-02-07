using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassToJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnTestData001_Save_Click(object sender, EventArgs e)
        {
            TestData001 tdTemp = new TestData001();

            tdTemp.StrData1 = txtStrData1.Text;
            tdTemp.StrData2 = txtStrData2.Text;
            tdTemp.IntData1 = Convert.ToInt32(numericIntData1.Text);
            tdTemp.IntData2 = Convert.ToInt32(numericIntData2.Text);

            //모델을 json 문자열로 변환
            string sJson = JsonConvert.SerializeObject(tdTemp);
            //파일로 저장
            File.WriteAllText(@"TestData001.json", sJson);
        }

        private void BtnTestData002_Save_Click(object sender, EventArgs e)
        {
            TestData002 tdTemp = new TestData002();

            tdTemp.DoubleData = Convert.ToDouble(txtDoubleData.Text);
            tdTemp.FloatData = (float)Convert.ToDouble(txtFloatData.Text);
            tdTemp.TypeTest1 = (Test1Type)Convert.ToInt32(numericTypeTest1.Text);
            tdTemp.TypeTest2 = (Test2Type)Convert.ToInt32(numericTypeTest2.Text);

            //모델을 json 문자열로 변환
            string sJson = JsonConvert.SerializeObject(tdTemp);
            //파일로 저장
            File.WriteAllText(@"TestData002.json", sJson);
        }



        private void BtnTestData001_Load_Click(object sender, EventArgs e)
        {
            //파일 읽기
            string sJson = File.ReadAllText(@"TestData001.json");
            //json문자열을 모델로 변환
            TestData001 tdTemp = JsonConvert.DeserializeObject<TestData001>(sJson);

            txtStrData1.Text = tdTemp.StrData1.ToString();
            txtStrData2.Text = tdTemp.StrData2.ToString();
            numericIntData1.Text = tdTemp.IntData1.ToString();
            numericIntData2.Text = tdTemp.IntData2.ToString();
        }

        private void BtnTestData002_Load_Click(object sender, EventArgs e)
        {
            //파일 읽기
            string sJson = File.ReadAllText(@"TestData002.json");
            //json문자열을 모델로 변환
            TestData002 tdTemp = JsonConvert.DeserializeObject<TestData002>(sJson);

            txtDoubleData.Text = tdTemp.DoubleData.ToString();
            txtFloatData.Text = tdTemp.FloatData.ToString();
            numericTypeTest1.Text = ((int)tdTemp.TypeTest1).ToString();
            numericTypeTest2.Text = ((int)tdTemp.TypeTest2).ToString();
        }

        private void BtnTestData001_View_Click(object sender, EventArgs e)
        {
            //파일 읽기
            string sJson = File.ReadAllText(@"TestData001.json");
            txtOutput.Text = sJson;
        }

        private void BtnbtnTestData002_View_Click(object sender, EventArgs e)
        {
            //파일 읽기
            string sJson = File.ReadAllText(@"TestData002.json");
            txtOutput.Text = sJson;
        }
    }
}
