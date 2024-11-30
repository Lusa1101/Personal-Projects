using MyMoneyPlanner.Models;
using MyMoneyPlanner.Repositories;
using System.Diagnostics;

namespace MyMoneyPlanner
{
    public partial class MainPage : ContentPage
    {
        string? finance;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnManage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TempManagerPage());
        }

    }

}
