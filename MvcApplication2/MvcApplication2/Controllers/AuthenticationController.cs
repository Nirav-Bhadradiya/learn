using System.Web.Mvc;
using System.Web.Security;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        public ActionResult Login()
        {
            return View("Login");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            var bal = new EmployeeBusinessLayer();
            if (bal.IsValidUser(u))
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }

    }
}
