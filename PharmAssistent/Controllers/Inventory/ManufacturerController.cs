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
    public class ManufacturerController : Controller
    {
        CheckDuplicatecs Duplicates = new CheckDuplicatecs();
        PharmContext db = new PharmContext();
        // GET: Manufacturer
        public ActionResult Index()
        {
            return View("Index", db.Manufacturers.OrderByDescending(m => m.ID).ToList());

        }
        public ActionResult Create()
        {

            return View();
        }
        [ActionName("Create")]
        [HttpPost]
        public ActionResult Create_Manufacturer()
        {
           
            Manufacturer manufacturer = new Manufacturer();
          
            TryUpdateModel(manufacturer);
            {
                bool count = Duplicates.CheckDuplicatecManufacturer(manufacturer);

                if (count == false)
                {
                    try
                    {
                        db.Manufacturers.Add(manufacturer);
                        db.SaveChanges();
                        ViewBag.msg = "Manufacturer  Saved !";  // SET IT TO VIEW
                    }
                    catch
                    {
                        ViewBag.msg = "Unable to Create";
                        //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    ViewBag.err = "Manufacturer  Already Exist";
                    return View();
                }

            }
            return RedirectToAction("Index", "manufacturer");
        }
        public ActionResult Detail(int ID)
        {

            PharmContext context = new PharmContext();
            Manufacturer output = new Manufacturer();
            try
            {
                output = context.Manufacturers.Single(m => m.ID == ID);
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
            Manufacturer output = new Manufacturer();
            try
            {
                output = context.Manufacturers.Single(m => m.ID == ID);
                context.Manufacturers.Remove(output);
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
            Manufacturer manufacturer = new Manufacturer();
            try
            {
                manufacturer = db.Manufacturers.Single(m => m.ID == ID);
            }
            catch
            {
                ViewBag.err = "ID not Found";
                return RedirectToAction("Index", "Manufacturer");
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(manufacturer);
        }
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult Edit_Manufacturer()
        {
            Manufacturer manufacturer = new Manufacturer();
            TryUpdateModel(manufacturer);
            {
                Manufacturer original = new Manufacturer();
                bool count = Duplicates.CheckDuplicatecManufacturer(manufacturer);

                if (count == false)
                {
                    try
                    {
                        original = db.Manufacturers.Single(m => m.ID == manufacturer.ID);

                        original.ID = manufacturer.ID;
                        original.ManufacturerName = manufacturer.ManufacturerName;
                        original.Description = manufacturer.Description;

                        db.SaveChanges();
                        ViewBag.msg = "Manufacturer  Updated";  // SET IT TO VIEW
                    }

                    catch
                    {
                        ViewBag.msg = "Unable to Update";
                        //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }

                }
                return RedirectToAction("Index", "manufacturer");
            }
        }
    }
}