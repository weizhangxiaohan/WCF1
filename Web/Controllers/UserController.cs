using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        UserService.UserServiceClient userService = new UserService.UserServiceClient();

        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            var u = new UserService.User
            {
                UserName = user.UserName,
                Password = user.PassWord,
                Email = user.Email
            };


            userService.RegisterUser(u);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserModel user,string returnUrl)
        {
            var result = await SignInManager.PasswordSignInAsync(user.UserName, user.PassWord, true, shouldLockout: false);
            return RedirectToAction("List","Product");
        }

        public JsonResult CheckUserNameIsExist(string userName)
        {
            if (!userService.IsExistByUserName(userName))
            {
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            return Json(false,JsonRequestBehavior.AllowGet);
        }
    }
}