using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMapp.Data.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
