//App.xaml.cs

namespace MyMoneyManager
{
    public partial class App : Application
    {
        public static Repository repo { get; private set; }
        public App(Repository unionRepo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            repo = unionRepo;
        }
    }
}