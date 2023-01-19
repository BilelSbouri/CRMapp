using CRMapp.Data;
using CRMapp.Model;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeOfUsers : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string lien;
        public string nomfb;
        public int id_page;

        public ListeOfUsers(string url,string nomfb,int id)
        {
            InitializeComponent();
            this.lien = url;
            this.nomfb = nomfb;
            this.id_page = id;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listofusers.ItemsSource = await firebaseHelper.GetAllAgents();
        }

      async private void listofusers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as User;
            string nameAgent = item.Nom.ToString();
            await firebaseHelper.AffectPage(id_page,lien, nomfb,nameAgent);
            CrossToastPopUp.Current.ShowToastSuccess("Page affected successfully");
            await Navigation.PopAsync();



        }
    }
}