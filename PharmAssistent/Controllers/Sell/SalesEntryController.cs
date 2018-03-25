using PharmAssistent.Models;
using PharmAssistent.Models.InventoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmAssistent.Controllers.Sell
{
    public class SalesEntryController : Controller
    {
        PharmContext context = new PharmContext();
        // GET: SalesEntry
        public ActionResult Index()
        {
            List<Stock> stock = new List<Stock>();
            stock = context.Stocks.ToList();
            return View(stock);
        }
    }
}