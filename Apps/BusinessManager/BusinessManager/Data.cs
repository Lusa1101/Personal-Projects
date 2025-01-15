using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManager.Models;

namespace BusinessManager
{
    public class Data
    {
        public Data() { }

        public List<Product_Category> Categories = new List<Product_Category>()
        {
            new Product_Category { Category_id = "CA6826", Name="Cannibis", DateCreated=DateOnly.FromDateTime(DateTime.Now), DateModified=DateOnly.FromDateTime(DateTime.Now) },
            new Product_Category { Category_id = "CA6827", Name="Snacks", DateCreated=DateOnly.FromDateTime(DateTime.Now), DateModified=DateOnly.FromDateTime(DateTime.Now) },
            new Product_Category { Category_id = "CA6828", Name="Cigarretes", DateCreated=DateOnly.FromDateTime(DateTime.Now), DateModified=DateOnly.FromDateTime(DateTime.Now) },
            new Product_Category { Category_id = "CA6829", Name="Smoking Accessories", DateCreated=DateOnly.FromDateTime(DateTime.Now), DateModified=DateOnly.FromDateTime(DateTime.Now) },
            new Product_Category { Category_id = "CA6830", Name="Wearing Accessories", DateCreated=DateOnly.FromDateTime(DateTime.Now), DateModified=DateOnly.FromDateTime(DateTime.Now) },
            new Product_Category { Category_id = "CA6831", Name="Other", DateCreated=DateOnly.FromDateTime(DateTime.Now), DateModified=DateOnly.FromDateTime(DateTime.Now) },
        };

        public List<Product_Subcategory> Subcategories = new List<Product_Subcategory>()
        {
            new Product_Subcategory { Subcategory_id="SC6738", Category_id="CA6826", Name="High Grade" },
            new Product_Subcategory { Subcategory_id="SC6739", Category_id="CA6826", Name="Cross" },

            new Product_Subcategory { Subcategory_id="SC6740", Category_id="CA6827", Name="Snacks" },
            new Product_Subcategory { Subcategory_id="SC6741", Category_id="CA6827", Name="Sweets" },

            new Product_Subcategory { Subcategory_id="SC6746", Category_id="CA6829", Name="Matches" },
        };

        public List<Product> Products = new List<Product>()
        {
            new Product { Product_id="P37836", Subcategory_id="SC6738", Name="Sunset Sherbet", Description="Comes with various flavours ..." },
            new Product { Product_id="P37837", Subcategory_id="SC6738", Name="Purple Haze", Description="For healing and focusing ..." },
            new Product { Product_id="P37838", Subcategory_id="SC6738", Name="Exodus Cheese", Description="It will slap so hard ..." },
            new Product { Product_id="P37839", Subcategory_id="SC6738", Name="PGM", Description="Comes with various flavours ..." },
            new Product { Product_id="P37840", Subcategory_id="SC6738", Name="Pitbull", Description="Comes with various flavours ..." },

            new Product { Product_id="P37841", Subcategory_id="SC6739", Name="Cross", Description="Comes with various flavours ..."},
        };

        public List<Stock> Stocks = new List<Stock>()
        {
            new Stock { Stock_id=563, Product_id="P37836", Cost_per_unit=20, Total_units=100, Unit_price=80 },
            new Stock { Stock_id=562, Product_id="P37840", Cost_per_unit=30, Total_units=50, Unit_price=120 },

            new Stock { Stock_id=636, Product_id="P37841", Cost_per_unit=5, Total_units=500, Unit_price=0 }
        };

        public List<Package> Packages = new List<Package>()
        {
            new Package { Package_id="PA6726", Name="Plain", Size="Small", Cost=12, Quantity=100 },
            new Package { Package_id="PA6727", Name="Plain with silver", Size="Large", Cost=18, Quantity=100 },
            new Package { Package_id="PA6728", Name="Skull", Size="Small", Cost=30, Quantity=50 }
        };

        public List<Packaging> Packagings = new List<Packaging>()
        {
            new Packaging { Packaging_id="PKG3672", Package_id="PA6726", Stock_id=636, Quantity=40, Unit_price=5 },
            new Packaging { Packaging_id="PKG3672", Package_id="PA6726", Stock_id=636, Quantity=40, Unit_price=10 },
            new Packaging { Packaging_id="PKG6736", Package_id="PA6727", Stock_id=636, Quantity=20, Unit_price=50 },
            new Packaging { Packaging_id="PKG2836", Package_id="PA6728", Stock_id=636, Quantity=30, Unit_price=15 }
        };

        public List<Essential> Essentials = new List<Essential>()
        {
            new Essential { Essential_id=67, Name="White bread" },
            new Essential { Essential_id=68, Name="Groceries" },
            new Essential { Essential_id=69, Name="Beer" }
        };

        public List<Expense> Expenses = new List<Expense>()
        {
            new Expense { Expence_id=832, Name="Beer", Type="Personal", Amount=100 },
            new Expense { Expence_id=893, Name="Groceries", Type="Personal", Amount=999.99m }
        };

    }
}
