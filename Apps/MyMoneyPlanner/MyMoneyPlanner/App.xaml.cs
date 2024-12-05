using MyMoneyPlanner.Repositories;

namespace MyMoneyPlanner
{
    public partial class App : Application
    {
        public static IncomeRepository repo {  get; private set; }
        public App(IncomeRepository incomeRepo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            repo = incomeRepo;
        }
    }
}
