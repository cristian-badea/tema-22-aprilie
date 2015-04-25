using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestiunePersoane
{
    public enum leaveTypeEnum 
    { 
        medical ,
        holiday ,
        other 
    };
    class Leave
    {
        public DateTime startingDate;
        public int duration;
        public leaveTypeEnum leaveType;
        public Employee employee;

        public Leave(DateTime startingDate, int duration, leaveTypeEnum leaveType)
        {
            this.startingDate = startingDate;
            this.duration = duration;
            this.leaveType = leaveType;
        }
    }
}
