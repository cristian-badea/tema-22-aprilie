using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiunePersoane
{
    class Program
    {
        static void Main(string[] args)
        {
            //testam functionalitatea codului
            DateTime dataNasterii = new DateTime(1990,12,8);
            DateTime dataAngajarii = new DateTime(2015,1,10);
            Employee angajat1 = new Employee ("Badea", "Cristian", dataNasterii, dataAngajarii, 500, 35);

            //testam metoda DisplayInfo
            angajat1.DisplayInfo();

            //testam metoda AddNewLeave
            //cazul 1 - concediu mai mic decat zile disponibile, ar tb sa mearga
            DateTime ziuaConcediu1 = new DateTime(2015,3,20);
            Leave concediu1 = new Leave(ziuaConcediu1, 10, "medical");
            angajat1.AddNewLeave(concediu1);

            angajat1.DisplayInfo();

            //cazul 2 - concediu mai mare decat zile disponibile ( acum avem 25 de zile disponibile )
            DateTime ziuaConcediu2 = new DateTime(2015, 4, 20);
            Leave concediu2 = new Leave(ziuaConcediu1, 30, "holiday");
            try
            {
                angajat1.AddNewLeave(concediu2);
            }
            catch(NegativeLeaveDays exception)
            {
                Console.WriteLine(exception.Message);
            }

            angajat1.DisplayInfo();

            //mai adaugam niste concedii
            DateTime ziuaConcediu3 = new DateTime(2015, 4, 10);
            Leave concediu3 = new Leave(ziuaConcediu3, 7, "holiday");
            angajat1.AddNewLeave(concediu3);

            angajat1.DisplayInfo();

            DateTime ziuaConcediu4 = new DateTime(2015, 5, 10);
            Leave concediu4 = new Leave(ziuaConcediu4, 3, "medical");
            angajat1.AddNewLeave(concediu4);

            angajat1.DisplayInfo();

            //testam lista de concedii
            angajat1.ShowAllLeaves(2015);

            Console.ReadKey();
        }
    }
}
