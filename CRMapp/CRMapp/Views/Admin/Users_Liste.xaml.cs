using CRMapp.Data;
using CRMapp.Data.Interfaces;
using CRMapp.Model;
using CRMapp.Views.Admin;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Users_Liste : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        
        public Users_Liste()
        {
            InitializeComponent();      
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            userlist.ItemsSource = await App.Database.GetUsersAsync();
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(new AddUsers());
        }

       async private void Userlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User item = e.SelectedItem as User;   
            await Navigation.PushAsync(new UpdateUser(item.User_Type,item.ID,item.CIN.ToString(),item.Nom.ToString(),
            item.Prenom.ToString(),item.date_naissance,item.Username.ToString(),item.Password.ToString()));
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            var item = sender as Button;
            var useritem = item?.BindingContext as User;
            if (useritem.User_Type.ToString()=="Agent")
            {
               await firebaseHelper.DeleteAgent(useritem.ID); 
            }
            await App.Database.DeleteUserAsync(useritem);          
            CrossToastPopUp.Current.ShowToastSuccess("Utilisateur Supprimée avec succées");
            userlist.ItemsSource = await App.Database.GetUsersAsync();
        }

        private  void Search_Bar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listview_Search.IsVisible = e.NewTextValue.Length > 0;
            listview_Search.ItemsSource = App.Database.SearchUser(Search_Bar.Text);
        }
        
        private async void listview_Search_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (User)e.SelectedItem;
            var usertype = item.User_Type;
            var nomuser = item.Nom;
            var prenomuser = item.Prenom;
            await DisplayAlert(usertype, nomuser +"  "+ prenomuser, "Ok");
        }
    }
}
