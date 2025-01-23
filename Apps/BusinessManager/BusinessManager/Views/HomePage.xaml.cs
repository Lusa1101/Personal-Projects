using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Views
{
    partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnPointOfSale(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PointOfSale());
        }

        async void OnAddProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        async void OnStockPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StockPage());
        }

        async void OnPersonalExpenditure(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonalExpenditurePage());
        }

        async void OnPackaging(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PackagingPage());
        }

        async void OnManage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagePage());
        }

        async void OnTesting(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
