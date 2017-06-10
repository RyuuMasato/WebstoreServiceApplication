using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public virtual Product Product { get; set; }
    }
}
