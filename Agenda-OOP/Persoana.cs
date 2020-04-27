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
                Console.WriteLine(activities.name);
                Console.Write(activities.start+"-"+activities.finish+" ");
                Console.Write(activities.description+" ");
                Console.Write(activities.participants);

            }
        }

        public void AddActivity()
        {
            string name;
            string description;
            string startdate;
            string finishdate;
            string participants;
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

            Console.WriteLine("Other participants: ");
            participants=Console.ReadLine();

            acts.Add(new Activities(){name=name,description=description,start=start,finish=finish,participants=participants});



        }

    }
}