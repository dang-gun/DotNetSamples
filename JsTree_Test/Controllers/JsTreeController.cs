using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JsTree_Test.Model;

namespace JsTree_Test.Controllers
{
    /// <summary>
    /// https://www.jstree.com/docs/json/
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JsTreeController : ControllerBase
    {
        [HttpGet]
        [Route("ListGet")]
        public ActionResult<JsTreeItemModel[]> ListGet(int nId)
        {
            List<JsTreeItemModel> listChildren = new List<JsTreeItemModel>();

            switch(nId)
            {
                case 0:
                    listChildren.Add(new JsTreeItemModel { id = "1", text = "ajax 1", children = true });
                    listChildren.Add(new JsTreeItemModel { id = "2", text = "ajax 2", children = false });
                    break;

                case 1:
                    listChildren.Add(new JsTreeItemModel { id = "3", text = "ajax 3", children = false });
                    listChildren.Add(new JsTreeItemModel { id = "4", text = "ajax 4", children = true });
                    listChildren.Add(new JsTreeItemModel { id = "5", text = "ajax 5", children = false });
                    break;

                case 4:
                    listChildren.Add(new JsTreeItemModel { id = "6", text = "ajax 6", children = false });
                    listChildren.Add(new JsTreeItemModel { id = "7", text = "ajax 7", children = false });
                    break;
            }


            return listChildren.ToArray();
        }
    }
}