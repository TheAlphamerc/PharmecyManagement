using PharmAssistent.Models;
using PharmAssistent.Models.InventoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmAssistent.Controllers.Inventory
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        { 

            PharmContext db = new PharmContext();
            List<Stock> stock = db.Stocks.OrderBy(x => x.Item.Name).ToList();

             ViewBag.count = stock.Count;
          //  var stocks = db.Stocks.Where(s => s.Qty > 0).Include(s => s.Item).OrderByDescending(x => x.ID);
            return View(stock);
        }
        public ActionResult Detail(int ID)
        {

            PharmContext context = new PharmContext();
          Stock output = new Stock();
            try
            {
                output = context.Stocks.Single(m => m.ID == ID);
                ViewBag.err = null;
                ViewBag.id = output.ItemID;
               
            }
            catch
            {
                ViewBag.err = "Invalid Id Selected";
             
                return View(output);
            }

            return View(output);
        }

        public ActionResult Delete(int ID)
        {

            PharmContext context = new PharmContext();
            Stock output = new Stock();
            try
            {
                output = context.Stocks.Single(m => m.ID == ID);
                context.Stocks.Remove(output);
                context.SaveChanges();

                ViewBag.msg = "Item  Removed";

            }
            catch
            {
                ViewBag.msg = "ID Not Found"; // Item not Found
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            PharmContext db = new PharmContext();
            Stock Stock = new Stock();
            try
            {
              Stock = db.Stocks.Single(m => m.ID == ID);
            }
            catch
            {
                ViewBag.err = "ID not Found";
                return RedirectToAction("Index", "Stock");
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(Stock);
        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit_Item()
        {
          Stock stocks = new Stock();
            PharmContext db = new PharmContext();
            TryUpdateModel(stocks);
            {
              Stock original = new Stock();
                try
                {
                    original = db.Stocks.Single(m => m.ID == stocks.ID);

                    original.ID = stocks.ID;
                    original.Batch = stocks.Batch;
                    original.CostPrice = stocks.CostPrice;
                    original.Expiry = stocks.Expiry;
                   // original.Item = stocks.Item;
                 //   original.ItemExpired = stocks.ItemExpired;
                    original.ItemID = stocks.ItemID;
                    original.ManufactureDate = stocks.ManufactureDate;
                    original.PurchaseID = stocks.PurchaseID;
                    original.Qty = stocks.Qty;
                    original.SellingPrice = stocks.SellingPrice;
                   

                    db.SaveChanges();
                    ViewBag.msg = "Supplier Deleted";  // SET IT TO VIEW
                }
                catch
                {
                    ViewBag.msg = "Unable to Update";
                    //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

                }

            }
            return RedirectToAction("Index", "Stock");
        }
    }
}