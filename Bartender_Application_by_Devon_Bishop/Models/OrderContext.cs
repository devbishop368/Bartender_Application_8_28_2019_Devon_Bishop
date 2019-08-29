using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Bartender_Application_by_Devon_Bishop.Models
{
    public class OrderContext
    {
        public string Connection { get; set; }
        public OrderContext(string connection)
        {
            this.Connection = connection;
        }

        private MySqlConnection ObtainConnection()
        {
            return new MySqlConnection(Connection);
        }
    }
}
