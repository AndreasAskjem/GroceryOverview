using GroceryOverviewLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace GroceryOverviewLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType db) //For adding alternative databases
        {
            if (db == DatabaseType.sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
        }


        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        
        public static string DropdownDefaultText()
        {
            return "All Products  ";
        }
    }
}
