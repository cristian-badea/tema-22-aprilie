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
        protected Dictionary<int, int> availableDaysOffPerYear;
        protected List<Leave> listaConcedii;

        public Employee(string lastName, string firstName, DateTime dateOfBirth, DateTime dateOfEmployment, int salary, int availableDaysOff)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.dateOfBirth = dateOfBirth;
            this.dateOfEmployment = dateOfEmployment;
            this.salary = salary;
            this.availableDaysOff = availableDaysOff;
            this.availableDaysOffPerYear = new Dictionary<int, int>();
            availableDaysOffPerYear.Add(dateOfEmployment.Year, availableDaysOff);
            this.listaConcedii = new List<Leave>();
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(lastName + " " + firstName + " has a salary : " + salary + "euro and " + availableDaysOffPerYear[DateTime.Now.Year] + " available days off in this year");
        }

        private void SubstractDays(Leave leave)
        {
            this.availableDaysOffPerYear[leave.startingDate.Year] = this.availableDaysOffPerYear[leave.startingDate.Year] - leave.duration;
        }

        public void AddNewLeave(Leave leave)
        {
            if (DateTime.Compare(leave.startingDate, this.dateOfEmployment) < 0)
            {
                Console.WriteLine("Concediul nu poate fi inregistrat inainte de data angajarii");
            }
            else
            {
                if (!ValidateLeaveInterval(leave))
                {
                    throw new ExistingLeaveInterval("Intervalul dorit este deja inregistrat pentru un concediu");
                }
                else
                {
                    if (!ValidateAvailableDaysOff(leave))
                    {
                        throw new NegativeLeaveDays("Numarul de zile ramase nu poate fi mai mare decat durata concediului");
                    }
                    else
                    {
                        this.SubstractDays(leave);
                        leave.employee = this;
                        listaConcedii.Add(leave);
                    }
                }
            }
        }

        public void ShowAllLeaves(int anConcediu)
        {
            foreach (Leave concediu in listaConcedii)
            {
                if (concediu.startingDate.Year == anConcediu)
                {

                    Console.WriteLine("Concediu incepand pe " + concediu.startingDate.Date.ToString("dd/MM/yyyy") + " pe durata de " + concediu.duration + " zile pe motiv de: " + concediu.leaveType);
                }
            }
        }

        private bool ValidateLeaveInterval(Leave leave)
        {
            DateTime leaveEndDate = leave.startingDate.AddDays(leave.duration);
            DateTime existingLeaveEndDate;
            foreach(Leave existingLeave in listaConcedii)
            {
                existingLeaveEndDate = existingLeave.startingDate.AddDays(existingLeave.duration);
                //data de start se regaseste intr-un leave existent
                if(DateTime.Compare(leave.startingDate, existingLeave.startingDate) > 0 && DateTime.Compare(leave.startingDate, existingLeaveEndDate) < 0)
                {
                    return false;
                }
                //data de sfarsit se regaseste intr-un leave existent
                if(DateTime.Compare(leaveEndDate, existingLeave.startingDate) > 0 && DateTime.Compare(leaveEndDate, existingLeaveEndDate) < 0)
                {
                    return false;
                }
                //un existing leave incepe in intervalul in care se doreste a se crea un leave nou
                if (DateTime.Compare(existingLeave.startingDate, leave.startingDate) > 0 && DateTime.Compare(existingLeave.startingDate, leaveEndDate) < 0)
                {
                    return false;
                }
                //un existing leave se termina in intervalul in care se doreste a se crea un leave nou
                if (DateTime.Compare(existingLeaveEndDate, leave.startingDate) > 0 && DateTime.Compare(existingLeaveEndDate, leaveEndDate) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateAvailableDaysOff(Leave leave)
        {
            if (this.availableDaysOffPerYear.ContainsKey(leave.startingDate.Year))
            {
                if (leave.duration > this.availableDaysOffPerYear[leave.startingDate.Year])
                    return false;
                else
                    return true;
            }
            else
            {
                this.availableDaysOffPerYear.Add(leave.startingDate.Year, this.availableDaysOff);
                return true;
            }
        }

        public void ShowAvailableDaysPerYear()
        {
            foreach(KeyValuePair<int,int> availableDaysInYear in availableDaysOffPerYear)
            {
                Console.WriteLine("Employee " + firstName + " " + lastName + " has " + availableDaysInYear.Value + " days available in " + availableDaysInYear.Key);
            }
        }

    }
}
