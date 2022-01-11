using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Entitiy;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
    }
}