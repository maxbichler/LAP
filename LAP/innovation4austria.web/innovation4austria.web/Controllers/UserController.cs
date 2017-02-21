using innovation4austria.dataAccess;
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
                    FormsAuthentication.SetAuthCookie(user.Email, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        [Authorize]
        public new ActionResult Profile(LoginModel email)
        {

            portalusers currentUser = UserAdministration.GetUser(User.Identity.Name);
            ProfileDataModel dataModel = AutoMapperConfig.CommonMapper.Map<ProfileDataModel>(currentUser);
            ProfileModel model = new ProfileModel()
            {
                ProfileData = dataModel,
                ProfilePassword = new ProfilePasswordModel()
            };

            return View("Profile", model);
        }
    }
}