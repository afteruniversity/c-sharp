using appUsandoTabbedPage.Views;

namespace appUsandoTabbedPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Principal();
        }
    }
}
