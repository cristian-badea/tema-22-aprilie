using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiunePersoane
{
    abstract class Person
    {
        protected string lastName;
        protected string firstName;
        protected DateTime dateOfBirth;

        public virtual void DisplayInfo()
        {
            Console.WriteLine(lastName + " " + firstName + " was born on " + dateOfBirth.Date.ToString("dd/MM/yyyy"));
        }
    }
   
}

