using CRMapp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CRMapp.ViewModel
{
  public class PausesViewModel
    {
        public ObservableCollection<Pause> Pauses { get; set; }

      
        public Command<Pause> RemoveCommand
        {
            get
            {
                return new Command<Pause>((pause) =>
                {
                    Pauses.Remove(pause);
                });
            }
        }
    }
}

