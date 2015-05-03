using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiunePersoane
{
    class ExistingLeaveInterval : Exception
    {
        public ExistingLeaveInterval()
        { }
        public ExistingLeaveInterval(string message) : base(message)
        {
        }
    }
}
