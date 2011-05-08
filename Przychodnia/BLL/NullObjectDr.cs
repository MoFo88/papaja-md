using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class NullObjectDr : Lekarz
    {
        public NullObjectDr()
            : base()
        {
            base.imie = "-";
            base.id = -1;
        }
    }
}
