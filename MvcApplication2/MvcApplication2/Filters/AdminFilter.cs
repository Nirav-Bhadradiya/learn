using System;
using System.Web.Mvc;

namespace MvcApplication2.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Convert.ToBoolean(filterContext.HttpContext.Session["IsAdmin"]))
            {
                filterContext.Result = new ContentResult
                {
                    Content = "Unauthorized to access specified resource."
                };
            }
        }
    }
}