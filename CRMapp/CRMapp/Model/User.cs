using SQLite;
using System;

namespace CRMapp.Model
{
   public class User
    {
        [PrimaryKey, Column("User_ID")]
        public int ID { get; set; }
      
        public string Nom { get; set; }
       
        public string Prenom { get; set; }
       
        public string CIN { get; set; }
       
        public string User_Type { get; set; }
    
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string Page_url { get; set; }
      
        public DateTime date_naissance { get; set; }



    }

}
