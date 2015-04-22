using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiunePersoane
{
    class Leave
    {
        public DateTime startingDate;
        public int duration;
        public string leaveType;
        public Employee employee;

        public Leave(DateTime startingDate, int duration, string leaveType)
        {
            this.startingDate = startingDate;
            this.duration = duration;
            this.leaveType = leaveType;
        }

    }
}
