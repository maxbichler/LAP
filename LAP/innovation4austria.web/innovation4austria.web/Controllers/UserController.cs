using innovation4austria.dataAccess;
using innovation4austria.logic;
using innovation4austria.web.AppCode;
using innovation4austria.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static innovation4austria.logic.UserAdministration;

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
        public new ActionResult Profile()
        {
            portalusers currentUser = UserAdministration.GetUser(User.Identity.Name);
            ProfileModel model = new ProfileModel()
            {
                ProfileData = new ProfileDataModel()
                {
                    Email = currentUser.email,
                    Firstname = currentUser.firstname,
                    Lastname = currentUser.lastname
                },
                ProfilePassword = new ProfilePasswordModel()
            };
            return View("Profile", model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProfileData(ProfileDataModel model)
        {
            if (ModelState.IsValid)
            {
                DataResult result = UserAdministration.SaveProfile(User.Identity.Name, model.Firstname, model.Lastname);
                if (result == DataResult.success)
                {
                    TempData[Constants.Messages.SUCCESS] = Constants.Messages.SaveSuccess;
                }
                else
                {
                        TempData[Constants.Messages.ERROR] = Constants.Messages.SaveError;
                }
            }
            else
            {
                TempData[Constants.Messages.WARNING] = Constants.Messages.ProfileDataInvalid;
            }
            return RedirectToAction("Profile");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProfilePassword(ProfilePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (UserAdministration.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword) == PassResult.success)
                {
                    TempData[Constants.Messages.SUCCESS] = Constants.Messages.SaveSuccess;
                }
                else
                {
                    TempData[Constants.Messages.ERROR] = Constants.Messages.SaveError;
                }
            }
            else
            {
                TempData[Constants.Messages.WARNING] = Constants.Messages.ProfilePassInvalid;
            }
            return RedirectToAction("Profile");
        }
    }
}