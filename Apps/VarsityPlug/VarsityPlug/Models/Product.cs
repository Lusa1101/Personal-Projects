using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarsityPlug.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ? Name { get; set; }
        public string ? Description { get; set; }

        public string? ProductID { get; set; }

        public int SellerID {  get; set; }

        public double Price { get; set; }
        //public int SubCatagoryID { get; set; }

        //Additional
        public string? SubCategory { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public int SoldQuantity { get; set; }

    }
}
