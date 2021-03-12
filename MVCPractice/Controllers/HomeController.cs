using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            List<Employee> newList = new List<Employee>();
            SqlDataAdapter dapt = new SqlDataAdapter();
            
            SqlConnection conn = new SqlConnection("data source=.; database=practiceDB; integrated security=SSPI");
            dapt.SelectCommand = new SqlCommand("SELECT * FROM tb1", conn);

            dapt.Fill(dt);

            foreach(DataRow row in dt.Rows)
            {
                Employee emp = new Employee();
                emp.eID = int.Parse(row["eid"].ToString());
                emp.firstName = row["firstname"].ToString();
                emp.lastName = row["lastname"].ToString();
                emp.email = row["email"].ToString();
                emp.dateJoined = DateTime.Parse(row["datejoined"].ToString());
                emp.salary = int.Parse(row["salary"].ToString());
                newList.Add(emp);
            }

            return View(newList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}