using CRMapp.Model;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp.Views.Tableau_de_bord_Agent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemanderPause : ContentPage
    {
        
        public string Type;
        public DemanderPause()
        {
            InitializeComponent();
        }

       async private void Approuve_button_Clicked(object sender, EventArgs e)
        {
            if (toilette.IsToggled && café.IsToggled)
            {
                CrossToastPopUp.Current.ShowToastWarning("Les deux types de pause sont coché");
            }
            else
            {
                if (toilette.IsToggled)
                {
                    Type = "Pause Toilette";
                }
                else

                if (café.IsToggled)
                {
                    Type = "Pause Café";
                }

                var pause = new Pause
                {
                    Nom = NameEntry.Text,
                    Durée = duree.SelectedItem.ToString(),
                    Type_pause = Type,
                };

                await App.Database.SavePauseAsync(pause);
                CrossToastPopUp.Current.ShowToastSuccess("Demande de pause enregistrée");

                NameEntry.Text = string.Empty;
                café.IsToggled = false;
                toilette.IsToggled = false;
                duree.SelectedItem = null;
            }

        }
    }
}