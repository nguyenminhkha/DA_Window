using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLi
{
    class sqlcommand
    {
        private string query;
        private sqlconnection connection;

        public sqlcommand(string query, sqlconnection connection)
        {
            // TODO: Complete member initialization
            this.query = query;
            this.connection = connection;
        }
    }
}
