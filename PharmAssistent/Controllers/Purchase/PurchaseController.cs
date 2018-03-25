using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmAssistent.Models;
using PharmAssistent.Models.PurchaseModel;

namespace PharmAssistent.Controllers
{
   
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            PharmContext db = new PharmContext();
            List<Purchase> purchase = new List<Purchase>();

            purchase = db.PurchaseContext.SqlQuery("select * from Purchase").ToList();

            return View(purchase);
           // return View();
         
        }

        public ActionResult Details(string PurchaseID)
        {
            PharmContext db = new PharmContext();
            List<PurchaseItem> purchase = new List<PurchaseItem>();
            purchase = db.PurchaseItemContext.Where(m => m.PurchaseID == PurchaseID).ToList();
            return View(purchase);
            // return View();

        }
        [HttpGet]
        public ActionResult Edit(string PurchaseID)
        {
            PharmContext db = new PharmContext();
            Purchase purchase = new Purchase();
            try
            {
                purchase = db.PurchaseContext.Single(m => m.PurchaseID == PurchaseID);
            }
            catch
            {
                ViewBag.err = "ID not Found";
                return RedirectToAction("Index","Purchase");
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
                return View(purchase);
            // return View();

        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit_Purchase()
        {
            Purchase purchaseView = new Purchase();
            PharmContext db = new PharmContext();
            TryUpdateModel(purchaseView);
            {
                Purchase original = new Purchase();
                try
                {
             
                    original = db.PurchaseContext.Single(m => m.PurchaseID == purchaseView.PurchaseID);

                    original.PurchaseID = purchaseView.PurchaseID;
                    original.Amount = purchaseView.Amount;
                    original.Date = purchaseView.Date;
                    original.Description = purchaseView.Description;
                    original.Discount = purchaseView.Discount;
                    original.Tax = purchaseView.Tax;
                    original.GrandTotal = purchaseView.GrandTotal;
                    original.IsPaid = purchaseView.IsPaid;
                    original.LastUpdated = DateTime.Now;

                    db.SaveChanges();
            }
                catch
                {
                    ViewBag.msg = "Unable to Update";
                    //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

                }

            }
         return   RedirectToAction("Index", "Purchase");
        }
        public ActionResult Delete(string PurchaseID)
        {
            PharmContext db = new PharmContext();
            List<PurchaseItem> purchaseitem = new List<PurchaseItem>();
            Purchase purchase = new Purchase();

            try
            {
                purchase = db.PurchaseContext.Single(m => m.PurchaseID == PurchaseID); ;
                purchaseitem = db.PurchaseItemContext.Where(m => m.PurchaseID == PurchaseID).ToList();

                    if (purchaseitem != null)
                    {
                        foreach (var i in purchaseitem)
                        {
                            db.PurchaseItemContext.Remove(i);
                        }
                        ViewBag.msg = "Details of " + purchase.PurchaseID + " Deleted";
                        db.PurchaseContext.Remove(purchase);
                        db.SaveChanges();
               

                }
                    else
                    {
                        ViewBag.msg = "Item Not Deleted";
                    }
                  
            }
            catch
            {
                ViewBag.err = "Unable to Delete ";

            }
            return RedirectToAction("Index");

        }
    }
}                                         