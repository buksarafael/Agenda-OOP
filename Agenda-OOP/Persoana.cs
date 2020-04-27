using System.Collections.Generic;
using System;
namespace Agenda_OOP
{
    internal class Persoana
    {
        public string nume { get; set; }
        public List<Activities> acts = new List<Activities>();


        public Persoana()
        {
            
        }

        

        public override string ToString()
        {
            return nume;
        }

        public void ShowAgenda()
        {
            foreach(var activities in acts){
            System.Console.WriteLine(activities);
            }
        }

        public void AddActivity()
        {
            string name;
            string description;
            string startdate;
            string finishdate;
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            string[] date;
            Console.WriteLine("Enter activity name: ");
            name=Console.ReadLine();
            Console.WriteLine("Enter activity description: ");
            description=Console.ReadLine();

            Console.WriteLine("Start date (YYYY/MM/dd/hh/mm)");
            startdate=Console.ReadLine();
            date= startdate.Split(new Char [] {',' , '/', ' ' });
            start = new DateTime(Convert.ToInt32(date[0]),Convert.ToInt32(date[1]),Convert.ToInt32(date[2]),Convert.ToInt32(date[3]),Convert.ToInt32(date[4]),00);

            Console.WriteLine("Finish date (YYYY/MM/dd/hh/mm)");
            finishdate=Console.ReadLine();
            date= finishdate.Split(new Char [] {',' , '/', ' ' });
            finish = new DateTime(Convert.ToInt32(date[0]),Convert.ToInt32(date[1]),Convert.ToInt32(date[2]),Convert.ToInt32(date[3]),Convert.ToInt32(date[4]),00);


        }

    }
}