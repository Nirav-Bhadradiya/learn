using System;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.ViewModels;

namespace MvcApplication2.Filters
{
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
    public class HeaderFooterFilter : ActionFilterAttribute
=======
    public class HeaderFooterFilter:ActionFilterAttribute
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var v = filterContext.Result as ViewResult;

            if (v != null) // v will null when v is not a ViewResult
            {
                var bvm = v.Model as BaseViewModel;
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
                if (bvm != null) //bvm will be null when we want a view without Header and footer
                {
                    bvm.UserName = HttpContext.Current.User.Identity.Name;
                    bvm.FooterData = new FooterViewModel();
                    bvm.FooterData.CompanyName = "StepByStepSchools"; //Can be set to dynamic value
=======
                if (bvm != null)//bvm will be null when we want a view without Header and footer
                {
                    bvm.UserName = HttpContext.Current.User.Identity.Name;
                    bvm.FooterData = new FooterViewModel();
                    bvm.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
                    bvm.FooterData.Year = DateTime.Now.Year.ToString();
                }
            }
        }
    }
}