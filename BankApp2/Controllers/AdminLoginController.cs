using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp2.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace BankApp2.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Index(LoginClass lc)
        {
           string mainconn = ConfigurationManager.ConnectionStrings["BANKEntities1"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(mainconn);
            string sqlquery = "select email,password from [dbo].[admin] where email=@email and password=@password";
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand(sqlquery, sqlCon);
            sqlCom.Parameters.AddWithValue("@email", lc.email);
            sqlCom.Parameters.AddWithValue("@password", lc.password);
            SqlDataReader sdr = sqlCom.ExecuteReader();
            if(sdr.Read())
            {
                Session["email"] = lc.email.ToString();
                return RedirectToAction("welcome");
            }
            else
            {
                ViewData["Message"] = "admin login details incorrect!";
            }
            sqlCon.Close();
            return View();
        }
        public ActionResult welcome()
        {
            return View();
        }
    }
}