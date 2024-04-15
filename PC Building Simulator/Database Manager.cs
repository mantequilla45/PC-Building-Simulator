using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Building_Simulator
{
    public class DatabaseManager
    {
        private OleDbConnection con;

        public DatabaseManager(string connectionString)
        {
            con = new OleDbConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public OleDbConnection GetConnection()
        {
            return con;
        }
    }
}
