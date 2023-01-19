using CRMapp.Helpers;
using CRMapp.Services.Dialog;
using CRMapp.Services.Navigation;
using CRMapp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMapp.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public BaseViewModel()
        {
            DialogService = ViewModelLocator.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool syncInProcess = false;
        public bool SyncInProcess
        {
            get { return syncInProcess; }
            set { SetProperty(ref syncInProcess, value); }
        }

        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

    }
}
