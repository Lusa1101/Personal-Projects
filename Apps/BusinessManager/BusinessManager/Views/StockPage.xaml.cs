using BusinessManager.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Views
{
    public partial class StockPage : ContentPage
    {
        Connect database = new Connect();
        Functions functions = new Functions();

        List<Product_Category> Categories = new List<Product_Category>();
        List<Product_Subcategory> Subcategories = new List<Product_Subcategory>();
        List<Product> Products = new List<Product>();
        List<Stock> Stocks = new List<Stock>();

        Product product;
        bool Needs_Packaging = false;

        public StockPage()
        {
            InitializeComponent();

            Categories = database.ReturnCategories();
            Subcategories = database.ReturnSubcategories();
            Products = database.ReturnProducts();
            Stocks = database.ReturnStocks();

            BindingContext = this;

            //Update the categories filter
            categories.ItemsSource = Categories;

            //Input checks
            costEntry.TextChanged += CheckIfCost;
            quantityEntry.TextChanged += CheckIfQuantity;
        }

        async void OnReceiptUpload(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick the related receipt",
                FileTypes = FilePickerFileType.Images
            });

            if (result == null)
                await DisplayAlert("Upload Confirmation", "Your receipt was not uploaded properly. Try Again", "Close");
            else
                await DisplayAlert("Upload Confirmation", "Your receipt was successfully uploaded.", "Close");
        }

        async void OnAddStock(object sender, EventArgs e)
        {
            int number = 1;

            if (functions.CheckEntry(costEntry) && functions.CheckEntry(quantityEntry) && product != null)
            {
                if (!Stocks.IsNullOrEmpty())
                    number = functions.GetLastId(Stocks) + 1;

                Stock stock = new Stock();

                stock.Stock_id = number;
                stock.Product_id = product.Product_id;
                stock.Cost = functions.DecimalConverter(costEntry.Text);
                stock.Total_units = functions.IntegerConverter(quantityEntry.Text);
                stock.Is_available = true;
                stock.Needs_Packaging = Needs_Packaging;
                stock.Unit_price = 0m;
                if (!Needs_Packaging && functions.CheckEntry(priceEntry))
                {
                    stock.Unit_price = functions.DecimalConverter(priceEntry.Text);
                }

                string result = database.InsertStock(stock);
                if (result == "1")
                {
                    await DisplayAlert("Stock", "Stock was successfully added.", "Okay");

                    //Set to null
                    functions.EntryToNull(costEntry);
                    functions.EntryToNull(quantityEntry);
                    functions.EntryToNull(priceEntry);

                    //Update stocks
                    Stocks = database.ReturnStocks();
                }
                else
                    await DisplayAlert("Stock", $"{result}", "Okay");
            }
            else
                await DisplayAlert("Stock", "Please don't leave entries blank.", "Okay");
        }

        void OnNeedsPackaging(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                Needs_Packaging = true;
                priceLayout.IsVisible = false;
            }
            else
            {
                Needs_Packaging = false;
                priceLayout.IsVisible = true;
            }
        }

        /***    Filter Handlers     ***/

        void OnCategorySelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;

            if (index != -1)
            {
                List<Product_Subcategory> list = new();
                list = Subcategories.Where(s => s.Category_id == Categories[index].Category_id).ToList();

                subcategories.ItemsSource = list;
            }
        }

        void OnSubcategorySelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;
            var subcategory = (Product_Subcategory)picker.SelectedItem;

            Debug.WriteLine(subcategory.Name);

            if (index != -1)
            {
                List<Product> list = new();
                list = Products.Where(p => p.Subcategory_id == subcategory.Subcategory_id).ToList();

                products.ItemsSource = list;
            }
        }

        void OnProductSelected(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int index = picker.SelectedIndex;

            if(index != -1)
            {
                product = (Product)picker.SelectedItem;

                Debug.WriteLine(product.Name);
            }
        }

        /***    End of Filter Handlers     ***/


        /***        Input Checks        ***/

        void CheckIfCost(object sender, TextChangedEventArgs e)
        {
            char[] arr = { '.', ',' };

            if(e.NewTextValue != null)
            {
                if (e.NewTextValue.Any(c => char.IsDigit(c)) && e.NewTextValue.Any(c => c == '.') || e.NewTextValue.Any(c => c == ','))
                {
                    cost.IsVisible = false;
                }
                else if (costEntry.Text.Length > 0 && e.NewTextValue.Any(c => char.IsLetter(c)))
                {
                    cost.Text = "Please enter a decimal value.";
                    cost.IsVisible = true;
                }
                else
                    cost.IsVisible = false;
            }
        }
        void CheckIfQuantity(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue != null)
            {
                if (quantityEntry.Text.Length > 0 && e.NewTextValue.All(c => char.IsDigit(c)))
                {
                    quantity.IsVisible = false;
                }
                else
                {
                    quantity.Text = "Please enter an integer value";
                    quantity.IsVisible = true;
                }
            }
        }
        /***        End of Input Checka     ***/
    }
}
