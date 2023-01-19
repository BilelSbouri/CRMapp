using CRMapp.Model;
using Plugin.Toast;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginAdmin : ContentPage
    {
       
        public LoginAdmin()
        {
            InitializeComponent();
            var assembly = typeof(LoginAdmin);
            Admin.Source = ImageSource.FromResource("CRMapp.Assets.Images.Adminlogo.png", assembly);
        }

        async private void Loginbutton_Clicked(object sender, EventArgs e)
        {
            if (AdminName.Text == "Admin" && passwordField.Text == "LeaderSTC")
            {
                await Navigation.PushAsync(new Users_Liste());
                CrossToastPopUp.Current.ShowToastSuccess("Logged in successfully");
            }
            else
            {
                CrossToastPopUp.Current.ShowToastWarning("Wrong password or username");
            }
        }
    }
}