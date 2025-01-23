using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Invoice_Line
    {
        public int Invoice_id { get; set; }
        public int Line_id {  get; set; }

        public int Stock_id { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Discount { get; set; } = 0m;
        public DateOnly? DateCreated { get; set; }
    }
}
