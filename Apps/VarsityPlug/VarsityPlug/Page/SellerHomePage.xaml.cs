using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarsityPlug.Models;
using VarsityPlug.Page;

namespace VarsityPlug
{
    public partial class SellerHomePage : ContentPage
    {
        string _username;
        public SellerHomePage()
        {
            InitializeComponent();

            Data();
        }

        void Data()
        {
            List<SellerProduct> sp = new List<SellerProduct>()
            {
                new SellerProduct { ItemName="Exodus Cheese", ItemPrice=149.99, InStock=79, IsAvailable=true, NumberOFSales=21, Proportion=45.87, Ratings=4},
                new SellerProduct { ItemName="Kushu", ItemPrice=99.99, InStock=0, IsAvailable=false, NumberOFSales=3, Proportion=12.6, Ratings=3},
                new SellerProduct { ItemName="Purple Haze", ItemPrice=69.99, InStock=34, IsAvailable=true, NumberOFSales=21, Proportion=85.87, Ratings=5}

            };

            myProducts.ItemsSource = sp;
        }

        async void OnAddProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage());
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
            else if (action == "Buyer")
                await Navigation.PushAsync(new HomePage(_username));
        }

        async void OnHomePage(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new SellerHomePage());
        }

        void OnSearch(object sender, EventArgs e)
        {

        }

        async void OnProductSelection(object sender, SelectionChangedEventArgs e)
        {
            SellerProduct? product = e.CurrentSelection.FirstOrDefault() as SellerProduct;
            await Navigation.PushAsync(new ProductPage(product));
        }
    }
}
