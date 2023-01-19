
using CRMapp.Data;
using CRMapp.Services.Navigation;
using CRMapp.ViewModel.Base;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp
{
    public partial class App : Application
    {
        static DBCnx database;
        public static string user = "Rendy";

        public static DBCnx Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBCnx(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3"));
                }
                return database;
            }
        }
    
        public App()
        {
            InitializeComponent();

            InitApp();

            if (Device.RuntimePlatform == Device.UWP)
            {
                InitNavigation();
            }
            MainPage = new NavigationPage(new SplashScreen());
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        private void InitApp()
        {
            ViewModelLocator.RegisterDependencies(false);
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
