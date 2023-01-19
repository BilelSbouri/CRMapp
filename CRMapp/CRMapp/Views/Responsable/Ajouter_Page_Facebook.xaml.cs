using CRMapp.Model;
using CRMapp.ViewModel;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp.Views.Responsable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ajouter_Page_Facebook : ContentPage
    {
       
        public Ajouter_Page_Facebook()
        {
            InitializeComponent();       
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            Random generator = new Random();
           int id_page= generator.Next(100000, 999999);
            if (NomFB.Text != null && lien_page.Text != null)
            {
                var pageFB = new PageFacebook
                {
                    ID =id_page ,
                    Nom_page = NomFB.Text,
                    Url = lien_page.Text,
                };
                await App.Database.SavePageAsync(pageFB);
                CrossToastPopUp.Current.ShowToastSuccess("Page added successfully");
                await Navigation.PushAsync(new ListeOfUsers(lien_page.Text, NomFB.Text,id_page));
                NomFB.Text = string.Empty;
                lien_page.Text = string.Empty;
            }
            else
            {
                CrossToastPopUp.Current.ShowToastWarning("Empty Fields");
            }
        }
        
       private void Open_Clicked(object sender, EventArgs e)
        {
            try 
            {
                string url = lien_page.Text;
                Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastWarning("Lien erronée!!");
            }
            }
    }

}