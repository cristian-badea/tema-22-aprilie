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
        [Description("medical")]
        med ,
        [Description("holiday")]
        hol ,
        [Description("other")]
        ot 
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

        public string getLeaveTypeDescription (leaveTypeEnum leaveType)
        {
            FieldInfo leaveTypeInfo = leaveType.GetType().GetField(leaveType.ToString());
            DescriptionAttribute[] leaveTypeAttribute = (DescriptionAttribute[])leaveTypeInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if(leaveTypeAttribute.Length > 0)
            {
                return leaveTypeAttribute[0].Description;
            }
            else
            {
                return leaveType.ToString();
            }
        }

    }
}
