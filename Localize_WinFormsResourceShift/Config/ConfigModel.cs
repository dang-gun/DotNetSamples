using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localize_WinFormsResourceShift.Config
{
    /// <summary>
    /// 설정 모델
    /// </summary>
    public class ConfigModel
    {
        /// <summary>
        /// 설정된 언어-국가 코드
        /// </summary>
        public string Language { get; set; }

        public ConfigModel()
        {
            this.Language = "en";
        }
    }
}
