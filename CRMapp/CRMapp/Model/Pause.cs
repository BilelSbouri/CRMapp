using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRMapp.Model
{
   public class Pause
    {
        
        public int ID { get; set; }

        public string Nom { get; set; }

        public string Durée { get; set; }

        public string Type_pause { get; set; }

        public string Decision { get; set; }
    }
}
