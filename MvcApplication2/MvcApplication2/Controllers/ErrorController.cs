using System;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        // GET: Error
        [AllowAnonymous]
        public ActionResult Index()
        {
            var e = new Exception("Invalid Controller or/and Action Name");
            var eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}