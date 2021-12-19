using Dapper;
using DevOpsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsTest.DAL
{
    class QuoteRepository : SqlLiteBaseRepository
    {
        public QuoteRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }
        public int InsertQuote(Quote quote)
        {
            string sql = "INSERT INTO Quotes (Name) Values (@Name);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, quote);
            }
        }

        public int DeleteQuote(string name)
        {
            string sql = "DELETE FROM Quotes WHERE Name = @Name;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, new { Name = name });
            }
        }

        public IEnumerable<Quote> GetQuotes()
        {
            string sql = "SELECT * FROM Quotes;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<Quote>(sql);
            }
        }

    }
}
