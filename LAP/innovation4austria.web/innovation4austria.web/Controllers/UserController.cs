using innovation4austria.logic;
using innovation4austria.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace innovation4austria.web.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                if (UserAdministration.CheckLogin(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }


        /// <summary>
        /// Login-Seite, zu der mittels Formular die Logindaten
        /// eines Benutzer geschickt werden.
        /// </summary>
        /// <param name="lm">Das LoginModel, das Benutzername enthält</param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult Login(LoginModel lm)
        //{

        //    if (UserAdministration.Login(lm.Email, lm.Password))
        //    {
        //        if (lm.RememberMe)
        //        {
        //            FormsAuthentication.SetAuthCookie(lm.Email, true);
        //        }
        //        else
        //        {
        //           
        //            FormsAuthentication.SetAuthCookie(lm.Email, false);
        //        }
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "User");
        }

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Home", "Index");
        //    }
        //}
    }
}