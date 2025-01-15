using BusinessManager.View;

namespace BusinessManager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }
    }

}
