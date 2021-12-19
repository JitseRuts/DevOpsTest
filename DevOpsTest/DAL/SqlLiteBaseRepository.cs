using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsTest.DAL
{
    class SqlLiteBaseRepository
    {
        public SqlLiteBaseRepository()
        {
        }

        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=QuoteDB.sqlite");
        }
        protected static bool DatabaseExists()
        {
            return File.Exists(@"QuoteDB.sqlite");
        }

        protected static void CreateDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE Quotes
                    (
                    Id                                  INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                                VARCHAR(100)
                    )");
            }
        }
    }
}
