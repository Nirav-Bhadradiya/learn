using System;
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
=======
using System.Collections.Generic;
using System.Linq;
using System.Web;
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
using System.Web.Mvc;

namespace MvcApplication2.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Convert.ToBoolean(filterContext.HttpContext.Session["IsAdmin"]))
            {
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
                filterContext.Result = new ContentResult
=======
                filterContext.Result = new ContentResult()
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
                {
                    Content = "Unauthorized to access specified resource."
                };
            }
        }
    }
}