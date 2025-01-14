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
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public DateOnly? DateCreated { get; set; }
    }
}
