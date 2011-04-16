using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class NoUserException : ApplicationException
    {
        public NoUserException() { }
        public NoUserException(string p) : base(p) { }
    }
}
