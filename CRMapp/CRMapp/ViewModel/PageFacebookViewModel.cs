using CRMapp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRMapp.ViewModel
{
    public class PageFacebookViewModel : BaseViewModel
    {
        public PageFacebookViewModel()
            {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync(""));

        }
        public ICommand OpenWebCommand { get; }

    }
    
}
