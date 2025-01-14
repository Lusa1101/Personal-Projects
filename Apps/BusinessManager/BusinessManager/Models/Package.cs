using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Package
    {
        public string? Package_id {  get; set; }
        public string? Name { get; set; }
        public string? Size { get; set; }
        public decimal? Cost { get; set; }
        public int Quantity { get; set; }
        public DateOnly? DateCreated { get; set; }
    }
}
