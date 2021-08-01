using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {        
        static List<Account> accList = new List<Account>
        {
            //new Account { Name = "admin", Password = "admin"},          
            new Account { Name = "dongbx", Password = "20172473"},           
            new Account { Name = "datnt", Password = "20172451"},
            new Account { Name = "trungpq", Password = "20172875"},
            new Account { Name = "khaipa", Password = "20172617"},
            new Account { Name = "thangnv", Password = "20172808"}

        };        

        [HttpGet]
        public IActionResult Login()
        {
            var cookieValue = Request.Cookies["UserLogin"];

            //string session = HttpContext.Session.GetString("UserLogin");
            if (cookieValue != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Verify(Account model)
        {
            //var users = accList.FindAll(x => x.Name == model.Name);            
            //if(users != null)
            //{
                foreach(var item in accList)
                {
                    if(item.Password == model.Password && item.Name == model.Name)
                    {
                        CookieOptions userCookies = new CookieOptions();
                        userCookies.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Append("UserLogin", model.Name, userCookies);

                        //HttpContext.Session.SetString("UserLogin", model.Name);
                        return RedirectToAction("Index", "Home");
                    }
                }
            //}           
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Logout()
        {
            CookieOptions userCookies = new CookieOptions();
            userCookies.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append("UserLogin", "", userCookies);

            //HttpContext.Session.Remove("UserLogin");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult AboutUs()
        {
            return View();
        }
    }
}

