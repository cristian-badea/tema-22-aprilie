using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiunePersoane
{
    class Employee : Person
    {
        protected DateTime dateOfEmployment;
        protected int salary;
        protected int availableDaysOff;
        protected List<Leave> listaConcedii;

        public Employee(string lastName, string firstName, DateTime dateOfBirth, DateTime dateOfEmployment, int salary, int availableDaysOff)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.dateOfBirth = dateOfBirth;
            this.dateOfEmployment = dateOfEmployment;
            this.salary = salary;
            this.availableDaysOff = availableDaysOff;
            this.listaConcedii = new List<Leave>();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(lastName + " " + firstName + " has a salary : " + salary + "euro and " + availableDaysOff + " available days off");
        }

        private void SubstractDays(int numberOfDays)
        {
            availableDaysOff -= numberOfDays;
        }

        public void AddNewLeave(Leave leave)
        {
            if (leave.duration > this.availableDaysOff)
            {
                throw new NegativeLeaveDays("Numarul de zile ramase nu poate fi mai mare decat durata concediului");
            }
            else
            {
                this.SubstractDays(leave.duration);
                leave.employee = this;
                listaConcedii.Add(leave);
            }
        }

        public void ShowAllLeaves(int anConcediu)
        {
            foreach( Leave concediu in listaConcedii)
            {
                if (concediu.startingDate.Year == anConcediu)
                {
                    
                    Console.WriteLine("Concediu incepand pe " + concediu.startingDate.Date.ToString("dd/MM/yyyy") + " pe durata de " + concediu.duration + " zile pe motiv de: " + concediu.getLeaveTypeDescription(concediu.leaveType));
                }
            }
        }

    }
}
