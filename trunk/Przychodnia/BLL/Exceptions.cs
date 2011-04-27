using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class NoUserException : ApplicationException
    {
        public NoUserException() :base("Nie odnaleziono użytkownika o podanym loginie i haśle!")  { }
        public NoUserException(string p) : base(p) { }
    }
}
