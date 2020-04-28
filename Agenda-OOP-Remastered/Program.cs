using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_OOP_Remastered
{
    class Program
    {
        
        /// <summary>
        /// Fiecare persoana va avea o agenda.
        /// Fiecare agenda/persoana are o lista diferita de activitati.
        /// Activitatile au atributele specificate pe platforma.
        /// Programul nu suporta CSV, in schimb suporta un proprietary text parsing, "sintaxa" poate fi verificata in persoane.txt
        /// </summary>

        public static List<Persoana> persoane = new List<Persoana>();
        public static string path = "..\\..\\persoane.txt";
        static void Main(string[] args)
        {
            if (File.Exists(path))
            {
                ReadFromFile(path);
            }
            Menu();
        }

        private static void ShowAgenda(int index)
        {
            persoane[index].ShowAgenda();
            AgendaOfPerson(index);
        }

        private static void AgendaOfPerson(int index)
        {
        Again:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            int counter=1;
            if (persoane[index].acts.Count() > 0)
            {
                
                Console.WriteLine("Legend:");
                Console.WriteLine("c - Create new activity");
                Console.WriteLine("d - Delete an activity");
                Console.WriteLine("s - Search for an activity by name");
                Console.WriteLine("a - See all activities between two dates");
                Console.WriteLine("b - Go back to agendas");
                
                Console.WriteLine($"1-{persoane[index].acts.Count()} - Select activity");
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{persoane[index].nume}'s activities:");
                Console.BackgroundColor = ConsoleColor.Black;
                foreach (Activities activity in persoane[index].acts)
                {
                    Console.WriteLine(counter + ". " + activity.name);
                    counter++;
                }
                counter = 1;

            }
            else
            {
                Console.WriteLine("There are no activities in this agenda. Press 'c' to create one. ");
            }
            Search:
            string input = Console.ReadLine();
            try
            {
                if (input == "d"&&persoane.Count()>0)
                {
                    DeleteActivity(index);
                }
                else if (input == "c" && persoane.Count() > 0)
                {
                    CreateActivity(index);
                }
                else if (input == "s")
                {
                    SearchActivity(index);
                    goto Search;
                }
                else if (input == "b")
                {
                    Menu();
                }
                else if (input == "a")
                {
                    SearchByDate(index);
                }
                else if (Convert.ToInt32(input) > 0 && Convert.ToInt32(input) <=persoane[index].acts.Count())
                {
                    ShowActivity(Convert.ToInt32(input) - 1, index);
                }
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Error");
                
            }
            goto Again;


        }

        private static void SearchByDate(int index)
        {
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            try
            {
                Console.Write("Enter date you wish to start searching from (YYYY/MM/dd): ");
                start = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter date you wish to start searching from (YYYY/MM/dd): ");
                finish = Convert.ToDateTime(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }

        }

        private static void SearchActivity(int index)
        {
            int i = 1;
            Console.WriteLine("Search: ");
            string search = Console.ReadLine();
            foreach(var activity in persoane[index].acts)
            {
                if (activity.name == search)
                {
                    Console.WriteLine($"{i}. {activity.name}");
                }
                i++;
            }
        }

        private static void ShowActivity(int index,int persindex)
        {
            Console.Clear();
            persoane[persindex].ShowActivity(index);
        }

        private static void CreateActivity(int index)
        {
            persoane[index].AddActivity();
        }

        private static void DeleteActivity(int index)
        {
            Console.WriteLine("Which activity should be deleted?");
            int index2 = Convert.ToInt32(Console.ReadLine());
            persoane[index].acts.RemoveAt(index2 - 1);
        }

        private static void ReadFromFile(string path)
        {
            int i=0;
            string[] details;
            StreamReader sr = new StreamReader(path);
            using (sr)
            {
                while (sr.Peek() > 0)
                {
                    details = sr.ReadLine().Split(',');
                    persoane.Add(new Persoana() { nume = details[0], prenume = details[1], phone = details[2], email = details[3], birthdate = Convert.ToDateTime(details[4]) });
                    while (sr.Peek() == '-')
                    {
                        sr.Read();
                        persoane[i].AddActivityFromFile(sr.ReadLine());
                    }
                    i++;
                }
            }
        }

        private static void Menu()
        {
        Start:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            int counter=1;
            if (persoane.Count() > 0)
            {
                Console.WriteLine("Legend:");
                Console.WriteLine("c - Create new person");
                Console.WriteLine("d - Delete a person");
                Console.WriteLine($"1-{persoane.Count()} - Select agenda");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Agendas:");
                Console.BackgroundColor = ConsoleColor.Black;
                foreach (Persoana pers in persoane)
                {
                    Console.WriteLine(counter + ". " + pers.nume);
                    counter++;
                }


            }
            else
            {
                Console.WriteLine("There are no users with an agenda. Press 'c' to create one. ");
            }
            string input = Console.ReadLine();
            try
            {
                if (input == "d")
                {
                    DeleteAgenda();
                }
                else if (input == "c")
                {
                    CreateAgenda();
                }
                else if (Convert.ToInt32(input) > 0 && Convert.ToInt32(input) <= persoane.Count())
                {
                    ShowAgenda(Convert.ToInt32(input) - 1);
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid input, try again");
                Console.ForegroundColor = ConsoleColor.White;
            }

            goto Start;
        }

        private static void DeleteAgenda()
        {
            Console.WriteLine("Which person should be deleted?");
            int index = Convert.ToInt32(Console.ReadLine());
            persoane.RemoveAt(index - 1);
        }

        private static void CreateAgenda()
        {
            string nume;
            string prenume;
            string phone;
            DateTime birthdate = new DateTime();
            string email;
            Console.Write("First name: ");
            nume = Console.ReadLine();

            Console.Write("Last name: ");
            prenume = Console.ReadLine();

            Console.Write("Enter a phone number: ");
            phone = Console.ReadLine();

            Console.Write("Enter your birthdate (YYYY/MM/dd): ");
            birthdate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Email: ");
            email = Console.ReadLine();

            persoane.Add(new Persoana() { nume = nume,prenume=prenume,phone=phone,birthdate=birthdate,email=email });
        }
    }
}
