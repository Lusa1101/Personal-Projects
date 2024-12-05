using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarsityPlug.Models
{
    public class SellerProduct
    {
        public string? ItemName {  get; set; }
        public bool IsAvailable { get; set; }
        public int InStock { get; set; }
        public int NumberOFSales { get; set; }
        public double Proportion { get; set; }
        public double ItemPrice { get; set; }
        public double Ratings {  get; set; }
    }
}
