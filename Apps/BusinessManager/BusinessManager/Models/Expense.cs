using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models
{
    public class Expense
    {
        public int Expence_id { get; set; }
        public string? Type { get; set; } = "Personal";
        public string? Name { get; set; }
        public decimal? Amount { get; set; }
        public DateOnly? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
