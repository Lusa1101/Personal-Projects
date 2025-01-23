using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManager.Models;

namespace BusinessManager.Views
{
    partial class ManagePage : ContentPage
    {
        Functions functions = new Functions();
        Connect database = new Connect();

        List<Product> Products = new List<Product>();
        List<Product_Category> Categories = new List<Product_Category>();
        List<Product_Subcategory> Subcategories = new List<Product_Subcategory>();
        List<Package> Packages = new List<Package>();

        List<String> strings = new List<String> { "Products", "Categories", "Subcategories", "Packages" };

        String Selected = "";
        public ManagePage()
        {
            InitializeComponent();

            //Upload data
            Products = database.ReturnProducts();
            Categories = database.ReturnCategories();
            Subcategories = database.ReturnSubcategories();
            Packages = database.ReturnPackages();

            filter.ItemsSource = strings;
        }

        void OnSelected(object sender, SelectionChangedEventArgs e)
        {
            switch(Selected)
            {
                case "Packages":
                    Package package = (Package)e.CurrentSelection;
                    Debug.WriteLine(package.Name);
                    break;
                case "Categories":
                    Product_Category category = (Product_Category)e.CurrentSelection;
                    Debug.WriteLine(category.Name);
                    break;
                case "Subcategories":
                    Product_Subcategory subcategory = (Product_Subcategory)e.CurrentSelection;
                    Debug.WriteLine(subcategory.Name);
                    break;
                default:
                    Product product = (Product)e.CurrentSelection;
                    Debug.WriteLine(product.Name);
                    break;
            }
        }

        void OnFilterSelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;
            Selected = (String)picker.SelectedItem;

            switch(Selected)
            {
                case "Packages":
                    collection.ItemsSource = Packages;
                    break;
                case "Categories":
                    collection.ItemsSource = Categories;
                    break;
                case "Subcategories":
                    collection.ItemsSource = Subcategories;
                    break;
                default:
                    collection.ItemsSource = Products;
                    break;
            }
        }
    }
}
