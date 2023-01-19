using CRMapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp.Views.Agent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeOfAgents : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ListeOfAgents()
        {
            InitializeComponent();         
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listofagents.ItemsSource = await firebaseHelper.GetAllAgents();
        }
    }
}