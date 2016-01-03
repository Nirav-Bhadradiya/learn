using System.Web.Mvc;
using System.Web.Security;
using BussinessLayers;
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
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                var bal = new EmployeeBusinessLayer();
                //New Code Start
                var status = bal.GetUserValidity(u);
                bool isAdmin;

                switch (status)
                {
                    case UserStatus.AuthenticatedAdmin:
                        isAdmin = true;
                        break;
                    case UserStatus.AuthentucatedUser:
                        isAdmin = false;
                        break;
                    default:
                        ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                        return View("Login");
                }

                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["IsAdmin"] = isAdmin;
                return RedirectToAction("Index", "Employee");
                //New Code End
            }
            return View("Login");
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}