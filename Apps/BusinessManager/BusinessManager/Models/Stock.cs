using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Stock
    {
        public int Stock_id { get; set; }
        public string? Product_id { get; set; }
        public decimal Cost_per_unit { get; set; }
        public int Total_units { get; set; }
        public decimal Unit_price { get; set; }
        public bool Is_available { get; set; } = true;
        public bool Needs_Packaging { get; set; } = false;
        public DateOnly? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
