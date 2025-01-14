using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Product
    {
        public string? Product_id { get; set; }
        public string? Name { get; set; }
        public string? Subcategory_id { get; set; }
        public string? Description { get; set; }
        public DateOnly? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

    }
}
