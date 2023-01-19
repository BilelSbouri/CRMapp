using CRMapp.Views.Agent;
using CRMapp.Views.Responsable;
using CRMapp.Views.Tableau_de_bord_Agent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageMaster : ContentPage
    {
        public ListView ListView;

        public HomePageMaster()
        {
            InitializeComponent();

            BindingContext = new HomePageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HomePageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomePageMasterMenuItem> MenuItems { get; set; }
            string test = "url";
            public HomePageMasterViewModel()
            {
                MenuItems = new ObservableCollection<HomePageMasterMenuItem>(new[]
                {
                    new HomePageMasterMenuItem { Id = 0, Title = " 📊 Dashboard ",TargetType=typeof(HomePage)},
                    new HomePageMasterMenuItem { Id = 1, Title = "⌛  Les demandes de pause",TargetType=typeof(ListDemandePause)},
                    new HomePageMasterMenuItem { Id = 2, Title = "✎  Ajouter page Facebook",TargetType=typeof(Ajouter_Page_Facebook) },
                    new HomePageMasterMenuItem { Id = 3, Title = "💬 Les conversations",TargetType=typeof(ChatPage)},
                    new HomePageMasterMenuItem { Id = 4, Title = "👥 List des agents",TargetType=typeof(ListeOfAgents)},
                    new HomePageMasterMenuItem { Id = 5, Title=  "🧾 List des pages facebook",TargetType=typeof(ListOfPages)},
                    new HomePageMasterMenuItem { Id = 6, Title = "⛔️ Deconnexion",TargetType=typeof(LoginPage) },

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void STC_SITE_Clicked(object sender, System.EventArgs e)
        {
            string url = "https://www.stc-nutrition.fr/en/";
            Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }
    }
}