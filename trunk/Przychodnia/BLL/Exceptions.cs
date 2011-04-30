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

    public class PasswordDontMatchException : ApplicationException
    {
        public PasswordDontMatchException() : base("Hasła nie są identyczne!") { }
        public PasswordDontMatchException(string p) : base(p) { }
    }

    public class UserExistException : ApplicationException
    {
        public UserExistException() : base("Użytkownik o podanym haśle juz istnieje!") { }
        public UserExistException(string p) : base(p) { }
    }

    public class BadDayIdentifyierException : ApplicationException
    {
        public BadDayIdentifyierException() : base("Błędny identyfikator!") { }
        public BadDayIdentifyierException(string p) : base(p) { }
    }
}
