using System;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Reflection;

using Mono.Web;

namespace WebViewCallJs_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            webBrowser1.Navigating += WebBrowser1_Navigating;
            //페이지 이동
            webBrowser1.Navigate(Application.StartupPath + @"\HTMLPage1.html");
        }

        private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

            if (e.Url.Host == "CSCommand".ToLower())
            {
                //MessageBox.Show("성공 : " + e.Url.Query);
                CallFun(e.Url.Query);
                e.Cancel = true;
            }
        }

        private void CallFun(string sQuery)
        {
            //?a=1&b=ccc
            //using Mono.Web;

            //쿼리 바인딩
            NameValueCollection nvcQuery = HttpUtility.ParseQueryString(sQuery);

            Type thisType = this.GetType();
            //호출할 메소드
            MethodInfo theMethod = thisType.GetMethod(nvcQuery["fname"]);
            //넘길 파라메타
            object[] parametersArray = new object[] { Convert.ToInt32( nvcQuery["a"])
                    , nvcQuery["b"] };
            theMethod.Invoke(this, parametersArray);
        }

        public void hello(int a, string b)
        {
            MessageBox.Show(string.Format("성공 : a={0}, b={1}", a, b));
        }
    }

    
}
