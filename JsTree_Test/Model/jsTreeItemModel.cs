using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsTree_Test.Model
{
    public class JsTreeItemModel
    {
        public string id { get; set; }
        //public string parent { get; set; }

        /// <summary>
        /// 노드에 표시될 텍스트
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 표시될 아이콘
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 상태값
        /// </summary>
        public JsTreeItemStateModel state { get; set; }

        /// <summary>
        /// 자식 노드 정보.
        /// 미리 바인딩 할때는 'JsTreeItemModel'을 배열로 넣는다.
        /// 미리 바인딩 하지 않을때는 bool 값을 넣어준다.
        /// </summary>
        public object children { get; set; }
    }

    /// <summary>
    /// jsTree노드의 상태
    /// </summary>
    public class JsTreeItemStateModel
    {
        /// <summary>
        /// 열려있는지 여부
        /// </summary>
        public bool opened { get; set; }
        /// <summary>
        /// 비활성화 여부
        /// </summary>
        public bool disabled { get; set; }
        /// <summary>
        /// 선택되어있는지 여부
        /// </summary>
        public bool selected { get; set; }
    }
    
}
