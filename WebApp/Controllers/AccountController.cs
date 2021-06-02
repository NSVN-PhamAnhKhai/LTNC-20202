using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {        
        static List<Account> accList = new List<Account>
        {
            new Account { Name = "admin", Password = "admin"},          
            new Account { Name = "dongbx", Password = "20172473"},           
            new Account { Name = "datnt", Password = "20172451"},
            new Account { Name = "trungpq", Password = "20172875"},
            new Account { Name = "khaipa", Password = "20172617"},
            new Account { Name = "thangnv", Password = "20172808"}

        };
        public List<Account> AccList
        {
            get
            {
                return accList;
            }
            set
            {
                accList = value;
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Verify(Account model)
        {
            var users = accList.FindAll(x => x.Name == model.Name);            
            if(users != null)
            {
                foreach(var item in users)
                {
                    if(item.Password == model.Password)
                    {                                             
                        return RedirectToAction("Index", "Home");
                    }
                }
            }           
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Logout()
        {           
            return RedirectToAction("Login", "Account");
        }
    }
}

