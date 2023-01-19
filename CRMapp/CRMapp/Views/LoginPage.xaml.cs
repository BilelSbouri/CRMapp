using CRMapp.Data;
using CRMapp.Model;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {      
        public bool res;

        public LoginPage()
        {
            InitializeComponent();
            var assemply = typeof(LoginPage);
            Image.Source = ImageSource.FromResource("CRMapp.Assets.Images.STC-Nutrition-Logo.jpg", assemply);
        }

        async private void SignIN_button_Clicked(object sender, EventArgs e)
        {
            if (UsernameEntry.Text != null && PasswordEntry.Text != null)
            {
                var user = new User
                {
                    Username = UsernameEntry.Text,
                    Password = PasswordEntry.Text
                };
                res = await App.Database.LoginIsValidAsync(user);
                if (res == true)
                {
                    await Navigation.PushAsync(new HomePage());
                    CrossToastPopUp.Current.ShowToastSuccess("Logged in successfully");
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastWarning("Wrong password or username");
                }
            }
            else
            {
                CrossToastPopUp.Current.ShowToastWarning("Enter User Name and Password Please");
            }
        }
        async private void Add_User_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginAdmin());
        }
    }
}