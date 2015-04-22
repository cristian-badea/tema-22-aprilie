using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiunePersoane
{
    class NegativeLeaveDays : Exception
    {
        public NegativeLeaveDays()
        {
        }

        public NegativeLeaveDays(string message) : base (message)
        {
        }
    }
}
