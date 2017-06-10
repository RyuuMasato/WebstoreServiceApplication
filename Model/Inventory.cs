using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Inventory
    {
        public Inventory()
        {
            InventoryItems = new List<InventoryItem>();
        }
        [Key]
        public int InventoryId { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}