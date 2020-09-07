using BankApp2.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BankApp2.Controllers
{
    
    public class AccountController : Controller
    {
        BANKEntities dbobj = new BANKEntities();
        // GET: Account
        //public ActionResult Account(Account obj)
        //{
        //  return View(obj);
        // }
        public ActionResult Account(Account obj)
        {
          return View(obj);
         }
     

        [HttpPost]
        public ActionResult AddAccount(Account model)
        {
            Account obj = new Account();
            if (ModelState.IsValid)
            {
                obj.Accid = model.Accid;
                obj.Accname = model.Accname;
                obj.Email = model.Email;
                obj.phone = model.phone;
                obj.balance = model.balance;
                if (model.Accid == 0)
                {
                    dbobj.Accounts.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State=EntityState.Modified;
                    dbobj.SaveChanges();
                }
            }
            ModelState.Clear();
            return View("Account");
        }
        public ActionResult AccountList()
        {
            var res = dbobj.Accounts.ToList();
            return View(res);
        }
        public ActionResult Delete(Account obj1)
        {
          var res = dbobj.Accounts.Where(x => x.Accid ==obj1.Accid).First();
            dbobj.Accounts.Remove(res);
            dbobj.SaveChanges();

            var list= dbobj.Accounts.ToList();
            return View("AccountList",list);
        }
   
      
    }
}