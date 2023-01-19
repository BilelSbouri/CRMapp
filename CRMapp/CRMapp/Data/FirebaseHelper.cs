using CRMapp.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMapp.Data
{
   public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://testdb-1ef08.firebaseio.com/");

        //Pauses Methodes
        #region
        public async Task<List<Pause>> GetAllPauses()
        {
            return (await firebase.Child("Pauses").OnceAsync<Pause>()).Select(item => new Pause
            {
                ID=item.Object.ID,
                Nom = item.Object.Nom,
                Durée = item.Object.Durée,
                Type_pause=item.Object.Type_pause

            }).ToList();
        }

        public async Task AddPauseDecision(string desicion, string duree)
        {
            await firebase.Child("PauseDecision").PostAsync(new Pause() { Decision = desicion, Durée = duree });
        }

        public async Task DeletePause(int Idpause)
        {
            var toDeletePause = (await firebase.Child("Pauses").OnceAsync<Pause>()).Where(a => a.Object.ID == Idpause).FirstOrDefault();
            await firebase.Child("Pauses").Child(toDeletePause.Key).DeleteAsync();

        }
        #endregion

        //Agents Methodes
        #region
        public async Task<List<User>> GetAllAgents()
        {
            return (await firebase.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                Nom = item.Object.Nom,
                Prenom = item.Object.Prenom,
                User_Type = item.Object.User_Type,
            }).ToList();
        }

        public async Task AddAgent(int id,string user_type,string username, string pwd,string nom,string prenom,DateTime birthday)
        {
            await firebase.Child("Users").PostAsync(new User() { ID=id,User_Type=user_type,Username = username, Password = pwd,Nom = nom, Prenom = prenom,date_naissance=birthday });
        }

        public async Task UpdateAgent(int id, string user_type, string nom, string prenom, DateTime Date_Naissance,string username, string pwd)
        {
            var toUpdatePerson = (await firebase.Child("Users").OnceAsync<User>()).Where(a => a.Object.ID == id).FirstOrDefault();
            await firebase.Child("Users").Child(toUpdatePerson.Key)
              .PutAsync(new User() {ID=id,User_Type=user_type,Nom=nom, Prenom = prenom,date_naissance=Date_Naissance,Username=username,Password=pwd});
        }


        public async Task DeleteAgent(int id_agent)
        {
            var toDeleteAgent = (await firebase.Child("Users").OnceAsync<User>()).Where(a => a.Object.ID == id_agent).FirstOrDefault();
            await firebase.Child("Users").Child(toDeleteAgent.Key).DeleteAsync();
        }

        #endregion

        //affecting facebook pages to agents 
        #region
        public async Task AffectPage(int id,string url,string name_Page,string Name_User)
        {
            await firebase.Child("AffectedPages").PostAsync(new PageFacebook() { ID=id,Url=url,Nom_page=name_Page,name_user = Name_User});
        }
        public async Task DeletePage(int Idpage)
        {
            var toDeletePause = (await firebase.Child("AffectedPages").OnceAsync<PageFacebook>()).Where(a => a.Object.ID == Idpage).FirstOrDefault();
            await firebase.Child("AffectedPages").Child(toDeletePause.Key).DeleteAsync();
        }
        #endregion

    }
}

