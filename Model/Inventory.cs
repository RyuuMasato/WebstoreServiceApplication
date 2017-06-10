using System.Collections.Generic;

namespace Model
{
    public class Inventory
    {
        public Inventory()
        {
            InventoryItems = new List<InventoryItem>();
        }
        public int InventoryId { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}