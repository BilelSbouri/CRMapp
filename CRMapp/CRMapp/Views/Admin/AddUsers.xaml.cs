using CRMapp.Data;
using CRMapp.Model;
using Plugin.Toast;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CRMapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUsers : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public AddUsers()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Random generator = new Random();
            idfield.Text = generator.Next(100000, 999999).ToString();
        }


        async private void Btn_ajouter_Clicked(object sender, EventArgs e)
        {
            if (Nomfield.Text == string.Empty || Prenomfield.Text == string.Empty || pickerUsers.SelectedItem == null 
                || UserNamefield.Text== string.Empty || Passwordfield.Text == string.Empty )
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
                    date_naissance=NaissanceDatePicker.Date,
                    CIN=CINfield.Text
                    
                };
                if (pickerUsers.SelectedItem.ToString() == "Agent")
                {
                    await firebaseHelper.AddAgent(Convert.ToInt32(idfield.Text), pickerUsers.SelectedItem.ToString(), 
                        UserNamefield.Text, Passwordfield.Text, Nomfield.Text, Prenomfield.Text,NaissanceDatePicker.Date);
                }                
                await App.Database.SaveUserAsync(user);
                CrossToastPopUp.Current.ShowToastSuccess("User added successfully");
                await Navigation.PopAsync();
            }


        }
    }
}