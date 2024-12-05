//Main.xaml.cs
using MyMoneyManager.Models;

namespace MyMoneyManager
{
    public partial class MainPage : ContentPage
    {
        string? finance;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }


    }

}