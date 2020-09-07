using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApp2.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BankApp2.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ValidateClass vc)
        {
            string maincon = ConfigurationManager.ConnectionStrings["BANKEntities"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(maincon);
            string sqlquery = "INSERT INTO [dbo].[admin] ([email],[password]) VALUES(@email,@password)";
            SqlCommand sqlcom = new SqlCommand(sqlquery,sqlCon);
            sqlCon.Open();
            sqlcom.Parameters.AddWithValue("@email", vc.email);
            sqlcom.Parameters.AddWithValue("@password", vc.password);
            sqlcom.ExecuteNonQuery();
            ViewData["Message"] = "admin record added successfully";
            sqlCon.Close();
            return View();
        }
    }
}