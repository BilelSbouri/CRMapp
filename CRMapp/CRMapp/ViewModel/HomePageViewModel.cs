using System;
using System.Collections.Generic;
using System.Text;

namespace CRMapp.ViewModel
{
   public class HomePageViewModel
    {

        public DateTime TodayDate
        {
            get => DateTime.Now;
        }
        public string acceptedPause
        {
            get => App.Database.NBofacceptedPauses().ToString();
        }
        public string pauseRefuser
        {
            get => App.Database.NBofRefusedPauses().ToString();
        }
        public string TotalPause
        {
            get => App.Database.NbPauses().ToString();
        }
        public string Agents
        {
            get => App.Database.numberofUser().ToString();
        }
        public HomePageViewModel()
        {

        }
        
    }
}
