using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManager.Models;
using Microsoft.IdentityModel.Tokens;

namespace BusinessManager.Views
{
    partial class PackagingPage : ContentPage
    {
        List<Product> Products = new();
        List<Product_Category> Categories = new();
        List<Product_Subcategory> Subcategories = new();
        List<Stock> Stocks = new();
        List<Package> Packages = new();
        List<Packaging> Packagings = new();

        //variables needed
        Stock stock;
        Package package;

        //Classes to be used
        Functions functions = new Functions();
        Connect database = new Connect();

        public PackagingPage() 
        {
            InitializeComponent();

            Products = database.ReturnProducts();
            Categories = database.ReturnCategories();
            Subcategories = database.ReturnSubcategories();
            Stocks = database.ReturnStocks();
            Packages = database.ReturnPackages();
            Packagings = database.ReturnPackagings();

            categories.ItemsSource = Categories;
            subcategories.ItemsSource = Subcategories;
            products.ItemsSource = Products;
            

            List<(String? Name, String? Size)> list = new();
            foreach(Package pkg in Packages)
                list.Add((pkg.Name, pkg.Size));

            packages.ItemsSource = list;
        }

        async void OnSubmitPackaging(object sender, EventArgs e)
        {
            if (functions.CheckEntry(quantity) && functions.CheckEntry(price))
            {
                int number = 1;
                Packaging packaging = new Packaging();

                if (!Packagings.IsNullOrEmpty())
                    number = functions.GetLastId(Packagings);

                packaging.Packaging_id = functions.CodeGenerator("Packaging", number);
                packaging.Stock_id = stock.Stock_id;
                packaging.Package_id = package.Package_id;
                packaging.Unit_price = functions.DecimalConverter(price.Text);
                packaging.Quantity = functions.IntegerConverter(quantity.Text);

                string result = database.InsertPackaging(packaging);
                if (result == "1")
                {
                    await DisplayAlert("Packaging", "Packaging was successfully added.", "Okay");

                    //Make nulls
                    functions.EntryToNull(price);
                    functions.EntryToNull(quantity);

                    //Update List
                    Packagings = database.ReturnPackagings();
                }
                else
                    await DisplayAlert("Packaging", result, "Okay");
            }
            else
                await DisplayAlert("Packaging", "Please make sure all the fields are filled.", "Okay");
        }

        /***    Picker Handlers    ***/

        void OnCategorySelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            Product_Category category = new Product_Category();
            category = (Product_Category)picker.SelectedItem;

            Debug.WriteLine("Category Selected: " + category.Name);

            //Update the subcategory filter
            List<Product_Subcategory> list = new();
            list = Subcategories.Where(s => s.Category_id == category.Category_id).ToList();
            subcategories.ItemsSource = list;
        }

        void OnSubcategorySelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            Product_Subcategory subcategory = new Product_Subcategory();
            subcategory = (Product_Subcategory)picker.SelectedItem;

            Debug.WriteLine("Subcategory Selected: " + subcategory.Name);

            //Update the product filter
            List<Product> list = new();
            list = Products.Where(p => p.Subcategory_id == subcategory.Subcategory_id).ToList();
            products.ItemsSource = list;
        }

        void OnProductSelected(object sender, EventArgs e)
        {
            var picker = (Picker)(sender);
            Product product = new Product();
            product = (Product)picker.SelectedItem;

            Debug.WriteLine("Product Selected" + product.Name);

            //Update the stock filter
            List<Stock> list = new();
            list = Stocks.Where(s => s.Product_id == product.Product_id && s.Is_available && s.Needs_Packaging).ToList();
            stocks.ItemsSource = list;
        }

        void OnStockSelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            this.stock = (Stock)picker.SelectedItem;
        }

        void OnPackageSelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;

            package = Packages[index];
        }

        /***    Picker Handlers    ***/
    }
}
