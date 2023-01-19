using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRMapp.Model
{
  public class PageFacebook
    {
        [PrimaryKey, Column("Page_ID")]
        public int ID { get; set; }

        public string Nom_page { get; set; }
        
        public string Url { get; set; } 
        public string name_user { get; set; }
    }
}
