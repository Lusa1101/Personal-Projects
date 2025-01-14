using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Invoice
    {
        public int Invoice_id { get; set; }
        public int Customer_id { get; set; }
        public DateOnly? DateCreated { get; set; }
    }
}
