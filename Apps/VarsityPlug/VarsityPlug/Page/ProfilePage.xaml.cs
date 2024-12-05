using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VarsityPlug.Page;

namespace VarsityPlug
{
    public partial class ProfilePage : ContentPage
    {
        string _username;
        public ProfilePage()
        {
            InitializeComponent();
        }
        async void OnFileSelect(object sender, EventArgs e)
        {
            var picture = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please select one image for your profile.",
                FileTypes = FilePickerFileType.Images
            });

            if (picture == null)
                return;

            var stream = await picture.OpenReadAsync();

            profilePic.Source = ImageSource.FromStream(() => stream);
        }

        async void OnPersonalDetails(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new PersonalDetails());
        }

        async void OnPurchaseHistory(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new PurchaseHistory());
        }

        void OnFileReport(object sender, TappedEventArgs e)
        {

        }

        void OnNeedHelp(object sender, TappedEventArgs e)
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
