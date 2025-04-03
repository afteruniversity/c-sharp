using exercicio02Grupo01.Views;

namespace exercicio02Grupo01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Principal());
        }
    }
}
