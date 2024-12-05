using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VarsityPlug.Page;

namespace VarsityPlug
{
    public partial class PersonalDetails : ContentPage
    {
        string _username;
        public PersonalDetails()
        {
            InitializeComponent();
        }

        async void OnProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        async void OnCart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(_username));
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
