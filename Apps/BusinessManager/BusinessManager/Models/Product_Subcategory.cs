using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Product_Subcategory
    {
        public string? Subcategory_id { get; set; }
        public string? Category_id { get; set; }
        public string? Name { get; set; }
        public DateOnly? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
