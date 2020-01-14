using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbmsSrc.Backend.Exceptions
{
    public class DBLogicException : Exception
    {
        public DBLogicException()
        {
        }

        public DBLogicException(string message)
            : base(message)
        {
        }

        public DBLogicException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
