using BusinessManager.Views;
using BusinessManager.Models;

namespace BusinessManager
{
    public partial class App : Application
    {
        public static ViewModels.MainViewModel mainViewModel { get; private set; }
        public static ViewModels.InvoiceSummaryViewModel summaryViewModel { get; private set; } 
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            mainViewModel = new();
            mainViewModel.RefreshList();

            summaryViewModel = new();
            summaryViewModel.RefreshList();
        }
    }
}
