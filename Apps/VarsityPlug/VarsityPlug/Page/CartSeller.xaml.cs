using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarsityPlug.Models;

namespace VarsityPlug
{
    public partial class CartSeller : ContentPage
    {
        double total = 0;
        string _username;
        public CartSeller()
        {
            InitializeComponent();

            Service();
        }

        void Service()
        {
            List<CartItem2> items = new List<CartItem2>()
            {
                new CartItem2 {ItemName="Kushu", ItemDescription="Medium-sized Kushu with unique art.", UnitPrice=99.99},
                new CartItem2 {ItemName="Purple Haze", ItemDescription="Premium marijuana per gram", UnitPrice=69.99}
            };

            cartByItem.ItemsSource = items;
 
            foreach (var item in items)
            {
                total += item.UnitPrice;
            }

            checkout.Text = total.ToString();
        }

        void OnItemQty(object sender, EventArgs e)
        {

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
            else if (action == "Buyer")
                await Navigation.PushAsync(new HomePage(_username));
        }

        async void OnHomePage(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new HomePage(_username));
        }
    }
}
