using PharmAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmAssistent.Controllers.Sell
{
    public class SalesController : Controller
    {
        PharmContext context = new PharmContext();
        // GET:Sales
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}