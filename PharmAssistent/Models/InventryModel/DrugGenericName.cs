using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmAssistent.Models.PurchaseModel;
using PharmAssistent.Models.InventoryModel;

namespace PharmAssistent.Models.InventoryModel
{
    [Table("DrugGenericName")]
    public class DrugGenericName
    {
        public int ID { get; set; }

       
        [Required]
        [StringLength(50, ErrorMessage="Maximum limit exceeded")]
        public string GenericName { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Item> Items { get; set; }

    }
}
