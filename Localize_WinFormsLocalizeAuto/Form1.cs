using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Localize_WinFormsLocalizeAuto.Config;

namespace Localize_WinFormsLocalizeAuto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //설정 읽기
            this.Config_Load();

            Thread.CurrentThread.CurrentCulture
                = new System.Globalization.CultureInfo(this._Config.Language);
            Thread.CurrentThread.CurrentUICulture
                = new System.Globalization.CultureInfo(this._Config.Language);

            InitializeComponent();
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2("en");
            frm2.Show();

            this._Config.Language = "en";
            this.Config_Save();
        }

        private void btnKorean_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2("ko");
            frm2.Show();

            this._Config.Language = "ko";
            this.Config_Save();
        }


        #region Config

        /// <summary>
        /// 설정파일 위치
        /// </summary>
        private readonly string _ConfigDir = "Config\\Config.json";

        /// <summary>
        /// 설정 내용
        /// </summary>
        private ConfigModel _Config = null;

        /// <summary>
        /// 설정 불러오기
        /// </summary>
        private void Config_Load()
        {
            FileInfo fi = new FileInfo(this._ConfigDir);
            if(true == fi.Exists)
            {//파일 있다.
                //설정파일 읽어 들이기
                string sJson = System.IO.File.ReadAllText(this._ConfigDir);

                //모델이 바인딩
                this._Config = JsonConvert.DeserializeObject<ConfigModel>(sJson);
            }
            else
            {//파일 없다
                this._Config = new ConfigModel();
            }
        }

        /// <summary>
        /// 설정 저장
        /// </summary>
        private void Config_Save()
        {
            if(null == this._Config)
            {//설정이 없다.
                this._Config = new ConfigModel();
            }

            //리스트를 파일로 변환
            string sConfigJson = JsonConvert.SerializeObject(_Config);

            //파일에 저장
            System.IO.File.WriteAllText(
                this._ConfigDir
                , sConfigJson);
        }
        #endregion

        private void btnReStart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
