using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLi
{
    class sqldataadapter
    {
        private sqlcommand command;

        public sqldataadapter(sqlcommand command)
        {
            // TODO: Complete member initialization
            this.command = command;
        }
        internal void fill(datatable data)
        {
            throw new NotImplementedException();
        }
    }
}
