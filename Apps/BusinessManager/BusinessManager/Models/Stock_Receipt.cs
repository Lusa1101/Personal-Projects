using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Stock_Receipt
    {
        public int Stock_id { get; set; }
        public Image? Image { get; set; }
        public DateOnly? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
