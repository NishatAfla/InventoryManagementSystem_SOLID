using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ItemDTO
    {
        public int ItemId { get; set; } // Unique identifier for the item
        public string Name { get; set; } // Name of the item
        public string Category { get; set; } // Category to which the item belongs
        public string Barcode { get; set; } // Unique barcode for scanning
        public int Quantity { get; set; } // Stock level
        public decimal SellingPrice { get; set; } // Price at which the item is sold
        public string Description { get; set; } // Additional details about the item
        public DateTime AddedDate { get; set; } // Date when the item was added
    }
}
