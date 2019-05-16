using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLi
{
    class sqlconnection
    {
        private string connectionstr;

        public sqlconnection(string connectionstr)
        {
            // TODO: Complete member initialization
            this.connectionstr = connectionstr;
        }

        internal void open()
        {
            //throw new NotImplementedException();
        }

        internal void close()
        {
            throw new NotImplementedException();
        }
    }
}
