using CRMapp.Data.Interfaces;
using CRMapp.Model;
using LiteDB;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRMapp.Data
{
    public class DBCnx
    {
        readonly SQLiteAsyncConnection _database;
        public IList<User> Empty { get; set; }
        public IList<PageFacebook> vide { get; set; }

        public DBCnx(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>();
            _database.CreateTableAsync<Pause>();
            _database.CreateTableAsync<PageFacebook>();
        }

        //User Database Methodes
        #region
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
    
        public Task<int> SaveUserAsync(User user)
        {   
           return _database.InsertAsync(user);    
        }

        public async Task UpdateUserAsync(User user)
        {
            await _database.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _database.DeleteAsync(user);
        }

        public async Task<bool> LoginIsValidAsync(User user)
        {
            var verification = await _database.Table<User>().FirstOrDefaultAsync(p => p.Username == user.Username && p.Password == user.Password);
            user = verification ?? user;
            return verification != null;
        }

        public List<User> SearchUser(string keyword)
        {
            var conn = _database.GetConnection();
            var getUsers = conn.Table<User>().Where( x => (x.Nom.Contains(keyword)) || (x.User_Type.Contains(keyword))).ToList();
            var resultCount = getUsers.Count();
            if (resultCount > 0)
            {
                return getUsers;
            }
            else
            {
                return (List<User>)Empty;
            }
        }

        public float numberofUser()
        {
            var conn = _database.GetConnection();
            var getUsers = conn.Table<User>();
            float resultCount = getUsers.Count();
            return resultCount;
        }

        public float numberofResponsable()
        {
            var conn = _database.GetConnection();
            var getResponsable = conn.Table<User>().Where(x => x.User_Type == "Responsable");
            float resultCount = getResponsable.Count();
            return resultCount;
        }

        public float numberofAgents()
        {
            var conn = _database.GetConnection();
            var getAgents = conn.Table<User>().Where(x=>x.User_Type == "Agent");
            float resultCount = getAgents.Count();
            return resultCount;
        }
        #endregion

        //Pause Database Methodes
        #region

        //GET_Methode
        public Task<List<Pause>> GetPauseAsync()
        {
            return _database.Table<Pause>().ToListAsync();
        }

        //Insert_methode 
        public Task<int> SavePauseAsync(Pause pause)
        {
            return _database.InsertAsync(pause);
        }

        //Delete_methode
        public Task<int> DeletePauseAsync(Pause pause)
        {
            return _database.DeleteAsync(pause);
        }

        //count_methode 
        public float NbPauses()
        {
            var conn = _database.GetConnection();
            var getPause = conn.Table<Pause>();
            float resultCount = getPause.Count();
            return resultCount;
        }
        public float NBofacceptedPauses()
        {
            var conn = _database.GetConnection();
            var getPause = conn.Table<Pause>().Where(x => x.Decision== "Accepter");
            float resultCount = getPause.Count();
            return resultCount;
        }
        public float NBofRefusedPauses()
        {
            var conn = _database.GetConnection();
            var getPause = conn.Table<Pause>().Where(x => x.Decision == "Refuser");
            float resultCount = getPause.Count();
            return resultCount;
        }
        #endregion 

        //Facebook Pages Database Methodes
        #region

        public Task<int> SavePageAsync(PageFacebook page)
        {
            return _database.InsertAsync(page);
        }

        public Task<List<PageFacebook>> GetPageAsync()
        {
            return _database.Table<PageFacebook>().ToListAsync();
        }

        public async Task DeletePageAsync(PageFacebook page)
        {
            await _database.DeleteAsync(page);
        }

        public List<PageFacebook> SearchPage(string keyword)
        {
            var conn = _database.GetConnection();
            var getPage = conn.Table<PageFacebook>().Where(x => (x.Nom_page.Contains(keyword))).ToList();
            var resultCount = getPage.Count();
            if (resultCount > 0)
            {
                return getPage ;
            }
            else
            {
                return (List<PageFacebook>)vide;
            }
        }
        #endregion
    }

}

