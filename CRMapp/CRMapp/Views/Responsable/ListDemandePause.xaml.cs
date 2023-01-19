using CRMapp.Data;
using CRMapp.Model;
using Plugin.Toast;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp.Views.Responsable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDemandePause : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public ListDemandePause()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listPause.ItemsSource = await firebaseHelper.GetAllPauses();
        }
        
      async  private void SwipeItem_Invoked_Cancel(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var pauseitem = item?.BindingContext as Pause;
            pauseitem.Decision = "Refuser";
            await App.Database.SavePauseAsync(pauseitem);
            await firebaseHelper.AddPauseDecision(pauseitem.Decision, pauseitem.Durée);
            await firebaseHelper.DeletePause(pauseitem.ID);
            CrossToastPopUp.Current.ShowToastWarning("Demande de pause Refusée");
            listPause.ItemsSource = await firebaseHelper.GetAllPauses();
        }
    
       async private void SwipeItem_Invoked_Confirm(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var pauseitem = item?.BindingContext as Pause;
            pauseitem.Decision = "Accepter";
            await App.Database.SavePauseAsync(pauseitem);
            await firebaseHelper.AddPauseDecision(pauseitem.Decision, pauseitem.Durée);
            await firebaseHelper.DeletePause(pauseitem.ID);
            CrossToastPopUp.Current.ShowToastSuccess("Demande de pause Confirmée");
            listPause.ItemsSource = await firebaseHelper.GetAllPauses();
        }

    }
}