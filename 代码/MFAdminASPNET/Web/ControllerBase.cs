/* ==============================================================================
 * 功能描述：ControllerBase  
 * 创 建 者：lixinmiao
 * 创建日期：2017/2/13 11:03:18
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Player.Contract
{
    /// <summary>
    /// ControllerBase
    /// </summary>
    public class ControllerBase : Controller
    {

        /// <summary>
        /// 分页大小
        /// </summary>
        public virtual int PageSize
        {
            get
            {
                return 15;
            }
        }


        public ContentResult PageReturn(string msg, string url = null)
        {
            var content = new StringBuilder("<script type='text/javascript'>");
            if (!string.IsNullOrEmpty(msg))
                content.AppendFormat("alert('{0}');", msg);
            if (string.IsNullOrWhiteSpace(url))
                url = Request.Url.ToString();
            content.Append("window.location.href='" + url + "'</script>");
            return this.Content(content.ToString());
        }


    }
}