using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmAssistent.Models;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using PharmAssistent.Repository;
namespace PharmAssistent.Models.PurchaseModel
{
    public class SupplierController : Controller
    {

        CheckDuplicatecs Duplicates = new CheckDuplicatecs();
        PharmContext db = new PharmContext();


        public ActionResult Index()
        {
            PharmContext context = new PharmContext();
            List<Supplier> supplier = new List<Supplier>();

            supplier = context.Suppliers.SqlQuery("Select * from Supplier").ToList();

            return View(supplier);
        }

        // GET: Supplier/Create
        [HttpGet]
        public ActionResult Create()
        {
        //    Supplier supplier = new Supplier();
        //   var id= db.Suppliers.SqlQuery("select MAX(ID) as ID from Supplier ");  GET LAST ID 
           
           
            return View();
        }
        [ActionName("Create")]
        [HttpPost]
        public ActionResult Create_Supplier()
        {
         
            Supplier supplier = new Supplier();
            TryUpdateModel(supplier);
            {
                bool count = Duplicates.CheckDuplicatecSupplier(supplier);
                if (count == false)
                {
                    try
                    {
                        db.Suppliers.Add(supplier);
                        db.SaveChanges();
                        ViewBag.msg = "Supplier  Save";  // SET IT TO VIEW
                    }
                    catch
                    {
                        ViewBag.msg = "Unable to save";
                        //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }

                }

                return View();
            }
        }
        public ActionResult Detail(int ID)
        {
           
            PharmContext context = new PharmContext();
            Supplier output = new Supplier();
             try
            {
                output = context.Suppliers.Single(m => m.ID == ID);
                ViewBag.err = null;
                ViewData["er"] = null;
            }
            catch
            {
                ViewBag.err = "Multiple Id Selected";
                ViewData["er"] = " InValid Supplier ID";
                return View(output);
            }

          return View(output);
        }
     
      public ActionResult Delete(int ID)
        {

            PharmContext context = new PharmContext();
            Supplier output = new Supplier();
            try
            {
                output = context.Suppliers.Single(m => m.ID == ID);
                context.Suppliers.Remove(output);
                context.SaveChanges();

                ViewBag.msg = "Supplier Removed";
              
            }
            catch
            {
                ViewBag.msg = "ID Not Found";
            }

            return    RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            PharmContext db = new PharmContext();
            Supplier supplier = new Supplier();
            try
            {
                supplier = db.Suppliers.Single(m => m.ID == ID);
            }
            catch
            {
                ViewBag.err = "ID not Found";
                return RedirectToAction("Index", "Supplier");
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(supplier);
           }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit_Supplier()
        {
            Supplier SupplierView = new Supplier();
            PharmContext db = new PharmContext();
            TryUpdateModel(SupplierView);
            {
                Supplier original = new Supplier();
               
                    bool count = Duplicates.CheckDuplicatecSupplier(original);
                    if (count == false)
                    {
                        try
                        {
                            original = db.Suppliers.Single(m => m.ID == SupplierView.ID);

                            original.ID = SupplierView.ID;
                            original.Address = SupplierView.Address;
                            original.Contact = SupplierView.Contact;
                            original.Description = SupplierView.Description;
                            original.Name = SupplierView.Name;

                            db.SaveChanges();
                            ViewBag.msg = "Supplier Deleted";  // SET IT TO VIEW
                        }
                        catch
                        {
                            ViewBag.msg = "Unable to Update";
                            //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

                        }
                    }
                }
               
            return RedirectToAction("Index", "Supplier");
        }


        [HttpPost]
        public ActionResult Supplier(Supplier supplier)
        {

          
           
          
                bool count = Duplicates.CheckDuplicatecSupplier(supplier);
                if (count == false)
                {
                    try
                    {
                        db.Suppliers.Add(supplier);
                        db.SaveChanges();
                        ViewBag.msg = "Supplier  Save";  // SET IT TO VIEW
                    }
                    catch
                    {
                        ViewBag.msg = "Unable to save";
                        //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }

                }

                return View();
          
        }
    }

}
