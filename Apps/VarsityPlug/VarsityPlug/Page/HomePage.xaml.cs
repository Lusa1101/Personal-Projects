using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

using VarsityPlug.Models;
using VarsityPlug.Page;

namespace VarsityPlug
{
    public partial class HomePage : ContentPage
    {
        List<Product> ? products;
        string _username;
        public HomePage(string id)
        {
            InitializeComponent();

            _username = id;

            Catalogue();
        }

        void Catalogue ()
        {
            products = new List<Product>()
            {
                new Product {Name="Mash RAM", Description="16GB DDR4 SO-DIMM", Category="Electronics", SubCategory="Computers",
                    ProductID="828", SellerID=330033, Price=1099.99, Quantity=10, SoldQuantity=3},
                new Product {Name="Mash Hard-drive", Description="1TB SSD", Category="Electronics", SubCategory="Computers",
                    ProductID="822", SellerID=330033, Price=3599.99, Quantity=5, SoldQuantity=0},
                new Product {Name="Mash Monitor", Description="24\" Screen Full HD Flat Screen", Category="Electronics", SubCategory="Computers",
                    ProductID="872", SellerID=330033, Price=2099.99, Quantity=7, SoldQuantity=3},
                new Product {Name="Mash MAC RAM", Description="16GB MAC DDR4 SO-DIMM", Category="Electronics", SubCategory="Computers",
                    ProductID="888", SellerID=330033, Price=1699.99, Quantity=17, SoldQuantity=5},
                new Product {Name="Kushu", Description="Medium-sized Kushu with unique art.", Category="Arts", SubCategory="Sculptures",
                    ProductID="292", SellerID=220022, Price=99.99, Quantity=20, SoldQuantity=7},
                new Product {Name="Purple Haze", Description="Premium marijuana per gram", Category="Health", SubCategory="Medicine",
                    ProductID="298", SellerID=220022, Price=69.99, Quantity=55, SoldQuantity=7}
            };

            catalogue.ItemsSource = products;
        }

        void OnSearch(object sender, EventArgs e)
        {
            if (homeSearch.Text == null)
            {
                search.Text = "Please enter something.";
                search.IsVisible = true;
            }

            //products.Find(homeSearch.Text)                
        }

        async void OnCart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(_username));
        }

        async void OnProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        async void OnChangeMode(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Switch Mode To:", "Cancel", null,
                "Seller", "Buyer");

            if (action == "Seller")         //Have t check if user has a SellerID
                await Navigation.PushAsync(new SellerHomePage());
           // else if (action == "Buyer")
             //   await Navigation.PushAsync(new HomePage());
        }

        async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            Product? currentProduct = (e.CurrentSelection.FirstOrDefault() as Product);

            //ItemPage(e.CurrentSelection.FirstOrDefault() as Product);
            if (currentProduct != null)
                await Navigation.PushAsync(new ItemPage(_username, currentProduct));
        }
    }
}
