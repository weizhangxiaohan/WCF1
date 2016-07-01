using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        UserService.UserServiceClient userService = new UserService.UserServiceClient();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            UserService.User u = new UserService.User();
            u.UserName = user.UserName;
            u.Password = user.PassWord;            

            userService.RegisterUser(u);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            //Membership.ValidateUser(user.UserName, user.PassWord);
            FormsAuthentication.RedirectFromLoginPage(user.UserName,false);

            //FormsAuthentication.Authenticate(user.UserName,user.PassWord);
            FormsAuthentication.SetAuthCookie(user.UserName,false);
            return RedirectToAction("List","Product");
        }
    }
}