using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsTree_Test.Model
{
    public class JsTreeResultModel
    {
        /// <summary>
        /// 전달용 데이터
        /// </summary>
        public JsTreeItemModel[] data { get; set; }

        /// <summary>
        /// 성공 여부
        /// </summary>
        public int Success { get; set; }
    }
}
