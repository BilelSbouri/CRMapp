using CRMapp.Data;
using CRMapp.Model;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp.Views.Responsable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfPages : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ListOfPages()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            FacebookList.ItemsSource = await App.Database.GetPageAsync();
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            var item = sender as Button;
            var pageitem = item?.BindingContext as PageFacebook;
           
          await firebaseHelper.DeletePage(pageitem.ID);
            
            await App.Database.DeletePageAsync(pageitem);
            CrossToastPopUp.Current.ShowToastSuccess("Page Supprimée avec succées");
            FacebookList.ItemsSource = await App.Database.GetPageAsync();
        }

        private void Search_Bar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listview_Search.IsVisible = e.NewTextValue.Length > 0;
            listview_Search.ItemsSource = App.Database.SearchPage(Search_Bar.Text);
        }

        private async void listview_Search_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (PageFacebook)e.SelectedItem;
            var pagename = item.Nom_page;
            await DisplayAlert("Resultat Recherche",pagename, "Ok");
        }
    }
}
