using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InventoryItem
    {
        [Key]
        public int InventoryItemId { get; set; }
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public virtual Product Product { get; set; }
    }
}
