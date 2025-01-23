using BusinessManager.Models;
using BusinessManager.Popups;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace BusinessManager.Views
{
    partial class PointOfSale : ContentPage
    {
        Data data = new Data();
        Connect database = new();
        Functions functions = new Functions();

        List<Product_Category> Categories = new();
        List<Product_Subcategory> Subcategories = new();
        List<Stock> Stocks = new();
        List<Packaging> Packagings = new();
        List<Product> Products = new();
        List<DisplayProduct> DisplayProducts = new();
        List<ProductGroup> ProductGroups = new();

        List<DisplayProduct> SelectedProducts = new();
        decimal Total = 0m;

        public PointOfSale() 
        {
            InitializeComponent();
            
            Categories = database.ReturnCategories();
            Subcategories = database.ReturnSubcategories();
            Stocks = database.ReturnStocks();
            Products = database.ReturnProducts();
            Packagings = database.ReturnPackagings();

            //Upload filter
            filter.ItemsSource = Categories;
            
            //Collection ItemsSource
            DisplayProductList();
            collection.ItemsSource = DisplayProducts;

            //Invoice total
            Total = 0m;
            SelectedProducts = new();
        }

        void GroupedProductList()
        {
            foreach (var subcategory in Subcategories)
            {
                ProductGroup productGroup = new();
                productGroup.Subcategory = subcategory.Name;
                productGroup.Products = DisplayProducts.Where(dp => dp.Subcategory_id == subcategory.Subcategory_id).ToList();

                ProductGroups.Add(productGroup);
            }
        }

        void DisplayProductList()
        {
            try
            {
                DisplayProducts = database.ReturnDisplayProducts(true);
                DisplayProducts.AddRange(database.ReturnDisplayProducts(false));
                

                GroupedProductList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        async void OnInvoiceSummary(object sender, EventArgs e)
        {
            await this.ShowPopupAsync(new InvoiceSummaryPage(SelectedProducts, Total));
        }

        void OnFilterChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            Product_Category selected = (Product_Category)picker.SelectedItem;
            Debug.WriteLine($"Selected Category: {selected.Name}");

            //Only show the list of product related to the filter
            if (selected.Category_id != null)
            {
                List<Product_Subcategory> subcategories = Subcategories.Where(s => s.Category_id == selected.Category_id).ToList();
                collection.ItemsSource = ReturnProducts(selected.Category_id);
            }
        }

        List<DisplayProduct> ReturnProducts(string category_id)
        {
            List<Product_Subcategory> subcategories = Subcategories.Where(s => s.Category_id == category_id).ToList();
            List<DisplayProduct> list = new();

            foreach(Product_Subcategory subcategory in subcategories)
            {
                foreach(DisplayProduct product in DisplayProducts)
                {
                    if (subcategory.Subcategory_id == product.Subcategory_id)
                        list.Add(product);
                }
            }

            return list;
        }

        void OnSelected(object sender, SelectionChangedEventArgs e)
        {
            DisplayProduct? product = e.CurrentSelection.FirstOrDefault() as DisplayProduct;

            if (product != null && !SelectedProducts.Contains(product))
            {
                SelectedProducts.Add(product);
                Debug.WriteLine("Added: " + product.Name);

                Total += product.Price;
            }
            else
                Debug.WriteLine("Failed to select product");

            invoiceTotal.Text = Total.ToString("#.00");

            //Unselect
            collection.SelectedItem = null;
        }
    }
}
