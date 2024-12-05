using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarsityPlug
{
    public partial class AddProductPage : ContentPage
    {
        string _username;
        public AddProductPage()
        {
            InitializeComponent();
        }

        void OnAddProduct(object sender, EventArgs e)
        {
            //return;
        }

        async void OnHomePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SellerHomePage());
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


    }
}
