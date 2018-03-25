using PharmAssistent.Models;
using PharmAssistent.Models.InventoryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmAssistent.Controllers.Inventory
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            PharmContext db = new PharmContext();
            //  List<Item> item = new List<Item>();
          var  items = db.items.ToList();

            //return View(item);
          //  var items = db.items.Include(i => i.DrugGenericName).Include(i => i.Manufacturer).OrderByDescending(i => i.ID);
            return View(items.ToList());
        }
       public JsonResult PopulateDrugGenericName()
        {
            //holds list of suppliers
            PharmContext context = new PharmContext();
            List<DrugGenericName> _supplierList = new List<DrugGenericName>();
                
       

            var supplierList = (from s in context.DrugGenericNames
                                select new { s.ID, s.GenericName }).ToList();

            //save list of suppliers to the _supplierList
            foreach (var item in supplierList)
            {
                _supplierList.Add(new DrugGenericName
                {
                    ID = item.ID,
                    GenericName = item.GenericName
                });
            }
            ViewBag.CategoryType = _supplierList;
            return Json(_supplierList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PopulateManufacturer()
        {
            //holds list of suppliers
            PharmContext context = new PharmContext();
            List<Manufacturer> _supplierList = new List<Manufacturer>();



            var supplierList = (from s in context.Manufacturers
                                select new { s.ID, s.ManufacturerName}).ToList();

            //save list of suppliers to the _supplierList
            foreach (var item in supplierList)
            {
                _supplierList.Add(new Manufacturer
                {
                    ID = item.ID,
                    ManufacturerName = item.ManufacturerName
                });
            }
            ViewBag.CategoryType = _supplierList;
            return Json(_supplierList, JsonRequestBehavior.AllowGet);
        }



        [ActionName("NewItem")]
       [HttpPost]
        public ActionResult Create_New_Item()
        {

            Item item = new Item();
            TryUpdateModel(item);

            if(ModelState.IsValid)
            {

                PharmContext db = new PharmContext();
                db.items.Add(item);
                db.SaveChanges();
                ViewBag.msg = "Data Save SuccessFully";

            }
            else
            {
                ViewBag.err = "Invalid Entry";
            }

            return View();
      

        }

        [ActionName("NewItem")]
        [HttpGet]
        public ActionResult  CreateItem()
        {
            
            return View();
        }

    }
}