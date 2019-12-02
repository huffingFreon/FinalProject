using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InventoryItem
    {
        public int InventoryItemID { get; set; }

        public string Description { get; set; }

        public bool CheckedOut { get; set; }

        public int? UserID { get; set; }

        public Professor User { get; set; }
    }
}
