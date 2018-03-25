using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using PharmAssistent.Service;

using PharmAssistent.Models.PurchaseModel;
using PharmAssistent.Models;
using PharmAssistent.Models.InventoryModel;
using PharmAssistent.ViewModel;

namespace PharmAssistent.Controllers
{
   
    public class PurchaseEntryController : Controller
    {

        PharmContext context = new PharmContext();
        // GET: PurchaseEntry
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

      //public JsonResult PopulatePurchadeID()
      //  {
          
        
      //      var ID = context.Database.ExecuteSqlCommand("SELECT SUM(ID) from  Purchase ");
      //      Supplier id = new Supplier();
      //      id.ID = ID;
      //      return Json(id, JsonRequestBehavior.AllowGet);

      //  }
        public JsonResult PopulateSupplier()
        {
            //holds list of suppliers
            List<Supplier> _supplierList = new List<Supplier>();

       

            var supplierList = (from s in context.Suppliers
                                select new { s.ID, s.Name }).ToList();

            //save list of suppliers to the _supplierList
            foreach (var item in supplierList)
            {
                _supplierList.Add(new Supplier
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            ViewBag.CategoryType = _supplierList;
            return Json(_supplierList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PopulateItem()
        {
            //holds list of suppliers
            List<Item> _itemList = new List<Item>();


            var itemList = (from s in context.items
                                select new { s.ID, s.Name }).ToList();

            //save list of suppliers to the _supplierList
            foreach (var item in itemList)
            {
                _itemList.Add(new Item
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            return Json(_itemList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SavePurchase(PurchaseEntryVM p)
        {

            bool status = false;

            if (p != null)
            {
                //new purchase object using the data from the viewmodel : PurchaseEntryVM
                Purchase purchase = new Purchase
                {
                    ID = p.ID,
                    PurchaseID = p.PurchaseID,
                    Date = p.Date,
                    SupplierID = p.SupplierID,
                    Amount = p.Amount,
                    Discount = p.Discount,
                    Tax = p.Tax,
                    GrandTotal = p.GrandTotal,
                    IsPaid = p.IsPaid,
                    Description = p.Description,
                    LastUpdated = DateTime.Now
                };
                Purchase_Copy purchase_copy = new Purchase_Copy();
                purchase_copy.PurchaseItem = new List<PurchaseItem>();
                //  populating the PurchaseItems from the PurchaseItems within ViewModel : PurchaseEntryVM
                foreach (var i in p.PurchaseItems)
                {
                    purchase_copy.PurchaseItem.Add(i);
                }
                Service.PurchaseEntryService service = new Service.PurchaseEntryService();
                service.AddPurchaseAndPurchseItems(purchase);
                service.InsertOrUpdateInventory(p.PurchaseItems);
                /////<if everything is sucessful, set status to true.>
                status = true;
            }
            // return the status in form of Json
            return new JsonResult { Data = new { status = status } };
        }
    }


    
}