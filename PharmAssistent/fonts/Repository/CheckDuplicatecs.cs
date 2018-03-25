using PharmAssistent.Models;
using PharmAssistent.Models.InventoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmAssistent.Repository
{
    public class CheckDuplicatecs
    {
        PharmContext db = new PharmContext();
      
        public bool CheckDuplicatecManufacturer(Manufacturer manufacturer)
        {
            Manufacturer manu = new Manufacturer();
            bool count = false;
            bool err = true;
            try
            {
                manu = db.Manufacturers.Single(m => m.ManufacturerName == manufacturer.ManufacturerName);
                if(manu != null )
                {  
                    count = true;
                }
                if(manufacturer.ID == manu.ID)
                {
                    count = false;
                }
            }
            catch
            {
                err = false;
            }

            return (count);
        }
        public bool CheckDuplicatecDrugGenericName(DrugGenericName drugGenericName)
        {
            DrugGenericName manu = new DrugGenericName();
            bool count = false;
            bool err = true;
            try
            {
                manu = db.DrugGenericNames.Single(m => m.GenericName == drugGenericName.GenericName);
                if (manu != null)
                {
                    count = true;
                }
                if (drugGenericName.ID == manu.ID)
                {
                    count = false;
                }
            }
            catch
            {
                err = false;
            }

            return (count);
        }
        public bool CheckDuplicatecSupplier(Supplier Supplier)
        {
            Supplier manu = new Supplier();
            bool count = false;
            bool err = true;
            try
            {
                manu = db.Suppliers.Single(m => m.Name == Supplier.Name);
                if (manu != null)
                {
                    count = true;
                }
                if (Supplier.ID == manu.ID)
                {
                    count = false;
                }
            }
            catch
            {
                err = false;
            }

            return (count);
        }


    }
}