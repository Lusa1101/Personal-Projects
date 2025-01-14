using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Packaging
    {
        public string? Packaging_id { get; set; } 
        public string? Package_id { get; set; }
        public int Stock_id { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_price  { get; set; } 

        public DateOnly? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
