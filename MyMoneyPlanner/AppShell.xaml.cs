namespace MyMoneyPlanner
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ManagerPage), typeof(ManagerPage));
            Routing.RegisterRoute(nameof(TempManagerPage), typeof(TempManagerPage));
            Routing.RegisterRoute(nameof(EditorPage), typeof(EditorPage));

        }
    }
}
