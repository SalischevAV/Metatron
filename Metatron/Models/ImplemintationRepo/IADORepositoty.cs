using Metatron.Models.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Metatron.Models.ImplemintationRepo
{
    public class IADOMySQLRepositoty<T> : IRepository<T>
        where T : class
    {
        private List<T> _db;
        private string _connectionString,
                       _sQLExpression;

        IEnumerable<T> GetItemList()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlCommand command = new MySqlCommand(_sQLExpression, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            T item = new T { };
                            _db.Add(item);
                        }
                    }
                }
            }
            return _db;
        }

    }
}