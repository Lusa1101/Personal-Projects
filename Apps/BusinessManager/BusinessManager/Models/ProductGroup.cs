using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class ProductGroup
    {
        public string? Subcategory { get; set; }
        public List<DisplayProduct> Products { get; set; } = new ();
    }
}
