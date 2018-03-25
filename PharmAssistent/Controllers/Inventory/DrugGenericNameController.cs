using PharmAssistent.Models;
using PharmAssistent.Models.InventoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmAssistent.Repository;

namespace PharmAssistent.Controllers.Inventory
{
    public class DrugGenericNameController : Controller
    {
        CheckDuplicatecs Duplicates = new CheckDuplicatecs();
       PharmContext db = new PharmContext();
        // GET: DrugGenericName
        public ActionResult Index()
        {
            return View(db.DrugGenericNames.ToList());
        }
        [ActionName("CreateGeneric")]
        [HttpGet]
        public ActionResult Create()
        {
           return View();
        }
        [ActionName("CreateGeneric")]
        [HttpPost]
        public ActionResult Create_Generic()
        {
            DrugGenericName drugGenericName = new DrugGenericName();
            TryUpdateModel(drugGenericName);
            {
                bool count = Duplicates.CheckDuplicatecDrugGenericName(drugGenericName);
                if (count == false)
                {
                    try
                    {
                        db.DrugGenericNames.Add(drugGenericName);
                        db.SaveChanges();
                        ViewBag.msg = "Generic  Save";  // SET IT TO VIEW
                    }
                    catch
                    {
                        ViewBag.msg = "Unable to save";
                        //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }

                }
            return RedirectToAction("Index", "DrugGenericName");
        }
}
        public ActionResult Detail(int ID)
        {

            PharmContext context = new PharmContext();
            DrugGenericName output = new DrugGenericName();
            try
            {
                output = context.DrugGenericNames.Single(m => m.ID == ID);
                ViewBag.err = null;
                ViewBag.id = output.ID;

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
            DrugGenericName output = new DrugGenericName();
            try
            {
                output = context.DrugGenericNames.Single(m => m.ID == ID);
                context.DrugGenericNames.Remove(output);
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
            DrugGenericName drugGenericName= new DrugGenericName();
            try
            {
                drugGenericName= db.DrugGenericNames.Single(m => m.ID == ID);
            }
            catch
            {
                ViewBag.err = "ID not Found";
                return RedirectToAction("Index", "DrugGenericName");
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(drugGenericName);
        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit_Generic()
        {
            DrugGenericName DrugGenericNames = new DrugGenericName();
            PharmContext db = new PharmContext();
            TryUpdateModel(DrugGenericNames);
            {
                DrugGenericName original = new DrugGenericName();

                bool count = Duplicates.CheckDuplicatecDrugGenericName(DrugGenericNames);
                if (count == false)
                {
                    try
                    {
                        original = db.DrugGenericNames.Single(m => m.ID == DrugGenericNames.ID);

                        original.ID = DrugGenericNames.ID;
                        original.GenericName = DrugGenericNames.GenericName;
                        original.Description = DrugGenericNames.Description;

                        db.SaveChanges();
                        ViewBag.msg = "Generic  Updated";  // SET IT TO VIEW
                    }
                    catch
                    {
                        ViewBag.msg = "Unable to Update";
                        //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }
                }
            }
            return RedirectToAction("Index", "DrugGenericName");
        }
    }
}