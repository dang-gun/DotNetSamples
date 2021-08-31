using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Localize_Resource.Resource;

namespace Localize_Resource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ChangeCulture("");
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            this.ChangeCulture("en");
        }

        private void btnKorean_Click(object sender, EventArgs e)
        {
            this.ChangeCulture("ko");
        }

        /// <summary>
        /// 언어 변경
        /// </summary>
        /// <param name="sCulture">변경할 언어-국가코드</param>
        public void ChangeCulture(string sCulture)
        {
            Thread.CurrentThread.CurrentCulture
                = new System.Globalization.CultureInfo(sCulture);
            Thread.CurrentThread.CurrentUICulture
                = new System.Globalization.CultureInfo(sCulture);


            this.Text = LangStr.Title;
            this.label1.Text = LangStr.Apple;
            this.label2.Text = LangStr.Pineapple;

        }
    }
}
