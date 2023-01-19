using CRMapp.Data;
using CRMapp.Model;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateUser : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public UpdateUser(string usertype, int id, string cin, string nom,
        string prenom, DateTime date_naissance, string username, string password)
        {
            InitializeComponent();
            pickerUsers.SelectedItem = usertype;
            idfield.Text = id.ToString();
            CINfield.Text = cin;
            Nomfield.Text = nom;
            Prenomfield.Text = prenom;
            NaissanceDatePicker.Date = date_naissance;
            UserNamefield.Text = username;
            Passwordfield.Text = password;          
        }

        async private void Btn_Update_Clicked(object sender, EventArgs e)
        {
            if (Nomfield.Text == string.Empty || Prenomfield.Text == string.Empty || pickerUsers.SelectedItem == null
               || UserNamefield.Text == string.Empty || Passwordfield.Text == string.Empty)
            {
                CrossToastPopUp.Current.ShowToastWarning("Empty Fields");
            }
            else
            {
                var user = new User
                {
                    ID = Convert.ToInt32(idfield.Text),
                    Nom = Nomfield.Text,
                    Prenom = Prenomfield.Text,
                    User_Type = pickerUsers.SelectedItem.ToString(),
                    Username = UserNamefield.Text,
                    Password = Passwordfield.Text,
                    date_naissance = NaissanceDatePicker.Date,
                    CIN = CINfield.Text
                };
                if (pickerUsers.SelectedItem.ToString() == "Agent")
                {
                  await firebaseHelper.UpdateAgent(Convert.ToInt32(idfield.Text), pickerUsers.SelectedItem.ToString(),
                      Nomfield.Text, Prenomfield.Text,NaissanceDatePicker.Date, UserNamefield.Text, Passwordfield.Text);
                }   
                await App.Database.UpdateUserAsync(user);                
                CrossToastPopUp.Current.ShowToastSuccess("User Updated successfully");
                await Navigation.PopAsync();
            }
        }

    }
 }
