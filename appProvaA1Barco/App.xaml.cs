using appProvaA1Barco.DAL;

namespace appProvaA1Barco
{
    public partial class App : Application
    {
        static crudSQLite _bd;
        public static crudSQLite BD
        {
            get
            {
                if(_bd == null)
                {
                    string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Barco.db3"
                    );
                    _bd= new crudSQLite(path);
                }
                return _bd;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new UI.ListaBarco());
        }
    }
}
