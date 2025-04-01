using appUsandoFlyoutPage.Views;

namespace appUsandoFlyoutPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FlyoutPageMenu();
        }
    }
}
