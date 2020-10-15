using System;
using System.Mvc;

namespace QuanTrac.Controllers
{
    public class HomeController : WebController
    {
        public ActionResult Default()
        {
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View(new Models.LoginInfo());
        }
        public ActionResult Login(Models.LoginInfo info)
        {
            Post("Account/Login", info);
            return Wait();
        }

        

        //public ActionResult Login()
        //{
        //    return View(new Models.LoginInfo());
        //}

        //public ActionResult Login(Models.LoginInfo info)
        //{
        //    User = null;

        //    Post("account.login", info);
        //    return Wait();
        //}

        //public ActionResult Exit()
        //{
        //    MyApp.Exit();
        //    return Done();
        //}
    }
}
