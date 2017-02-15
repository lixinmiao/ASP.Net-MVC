using Framework.Utility;
using MFAdminASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web;

namespace MFAdminASPNET.Controllers
{
    public class AuthController :BaseController
    {
        private MFAdminASPNETDB db = new MFAdminASPNETDB();

        [AuthorizeIgnore]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeIgnore]
        public ActionResult Login(string username, string password, string verifycode)
        {
         
            LoginInfo loginInfo = this.AccountService.Login(username, password);
          
            if (loginInfo != null)
            {
                this.CookieContext.UserToken = loginInfo.LoginToken;
                this.CookieContext.UserName = loginInfo.LoginName;
                this.CookieContext.UserId = loginInfo.UserID;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "用户名或密码错误");
                return View();
            }
        }

        public ActionResult Logout()
        {
            this.AccountService.Logout(this.CookieContext.UserToken);
            this.CookieContext.UserToken = Guid.Empty;
            this.CookieContext.UserName = string.Empty;
            this.CookieContext.UserId = 0;
            return RedirectToAction("Login");
        }

        public ActionResult ModifyPwd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ModifyPwd(FormCollection collection)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeIgnore]
        public ActionResult VerifyImage()
        {
            return View();

        }

    }
}
