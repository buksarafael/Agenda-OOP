using System;
using System.Collections.Generic;

namespace Agenda_OOP_Remastered
{
    internal class Persoana
    {
        public string nume { get; set; }
        public string prenume;
        public DateTime birthdate;
        public string email;
        public string phone;

        public List<Activities> acts = new List<Activities>();

        public Persoana()
        {

        }

        public void ShowActivity(int index)
        {
            Console.WriteLine(acts[index].name);
            Console.WriteLine("The activity starts on " + acts[index].start + " and ends on " + acts[index].finish);
            Console.WriteLine("");
            Console.WriteLine("Description: ");
            Console.WriteLine(acts[index].description);
            if (acts[index].participants != "")
            {
                Console.Write("Participants: ");
                Console.WriteLine(acts[index].participants);
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }


        public void ShowAgenda()
        {
            int i = 1;
            foreach (var activities in acts)
            {
                Console.Write(i + ": ");
                Console.Write(activities.name);
                i++;
                Console.WriteLine();
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
            name = Console.ReadLine();
            Console.WriteLine("Enter activity description: ");
            description = Console.ReadLine();

            Console.WriteLine("Start date (YYYY/MM/dd/hh/mm)");
            startdate = Console.ReadLine();
            date = startdate.Split(new Char[] { ',', '/', ' ' });
            start = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), 00);

            Console.WriteLine("Finish date (YYYY/MM/dd/hh/mm)");
            finishdate = Console.ReadLine();
            date = finishdate.Split(new Char[] { ',', '/', ' ' });
            finish = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), 00);

            Console.WriteLine("Other participants: ");
            participants = Console.ReadLine();

            acts.Add(new Activities() { name = name, description = description, start = start, finish = finish, participants = participants });
            foreach (var persoane in Program.persoane)
            {
                if (persoane.nume == participants)
                {
                    persoane.acts.Add(new Activities() { name = name, description = description, start = start, finish = finish, participants = participants });
                }
            }
        }


        public void AddActivityFromFile(string info)
        {
            string name;
            string description;
            string startdate;
            string finishdate;
            string participants="";
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            string[] date;
            string[] splut;




            splut = info.Split(',');

            name = splut[0];

            description = splut[3];


            startdate = splut[1];
            date = startdate.Split(new Char[] { '-', '/' });
            start = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), 00);


            finishdate = splut[2];
            date = finishdate.Split(new Char[] { '-', '/' });
            finish = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), 00);

            if (splut.Length==5)
            {
                participants = splut[4];
                foreach (var persoane in Program.persoane)
                {
                    if (persoane.nume == participants)
                    {
                        persoane.acts.Add(new Activities() { name = name, description = description, start = start, finish = finish, participants = participants });
                    }
                }
            }

            acts.Add(new Activities() { name = name, description = description, start = start, finish = finish, participants = participants });

        }
    }
}