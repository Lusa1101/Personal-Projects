using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Views
{
    partial class SignPage : ContentPage
    {
        public SignPage()
        {
            InitializeComponent();
        }

        public async void OnLogin(object sender, EventArgs e)
        {
            if(username.Text == "Ndivhuwo" && password.Text == "ndivhuwo")
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Sign in", "Your login details are incorrect.", "Try again");
            }
        }
    }
}
