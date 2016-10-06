using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using EasySales.Model.System;

namespace EasySales.WEB.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/Welcome/ 
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }

        // GET: /HelloWorld/GetTables/ 
        public string GetTables()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<ul>");
            foreach (var table in TableService.GetAll())
            {
                builder.Append(string.Format("<li>{0}</li>" , table.Name));
            }
            builder.Append("<ul>");


            return builder.ToString();
        }
    }
}