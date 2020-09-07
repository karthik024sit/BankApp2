using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp2.Context;
namespace BankApp2.Controllers
{
    public class HomeController : Controller
    {
        BANKEntities db = new BANKEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account obj,string btn)
        {
            if (btn == "Withdraw")
            {
                var data = db.Accounts.Where(obj1 => obj1.Accname == obj.Accname).FirstOrDefault();
                if (obj.balance <= data.balance)
                {
                    data.balance = data.balance - obj.balance;
                    int mess = db.SaveChanges();
                    if (mess == 1)
                    {
                        ViewBag.data = "witdraw done";
                    }
                    else
                    {
                        ViewBag.data = "witdraw unsuccessful";
                    }
                }
                else
                {
                    ViewBag.data = "Insufficient balance";
                }
            }
            else if (btn == "deposit")
            {
                var data = db.Accounts.Where(obj1 => obj1.Accname == obj.Accname).FirstOrDefault();
                data.balance += obj.balance;
                int mess = db.SaveChanges();
                if (mess == 1)
                {
                    ViewBag.data = "deposit successful";
                }
                else
                {
                    ViewBag.data = "deposit unsuccessful";
                }
            }

            else if (btn == "show")
            {
                var data = db.Accounts.Where(obj1 => obj1.Accname == obj.Accname).FirstOrDefault();
                ViewBag.show = data.balance;
            }


            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "This is the description page of my banking web application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "contact page.Contact us on any time on the address and email below";

            return View();
        }
    }
}