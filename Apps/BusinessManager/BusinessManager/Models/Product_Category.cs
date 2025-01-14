using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Product_Category
    {
        public string? Category_id { get; set; }
        public string? Name { get; set; }
        public DateOnly? DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? DateModified { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
