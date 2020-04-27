using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_OOP
{
    class Program
    {
        public static List<Persoana> persoane = new List<Persoana>();
        static void Main(string[] args)
        {
            //Asta este cea mai buna tema pe care am primit-o, serios :D
            
            Persoana p = new Persoana();
            string nume="";
            string input;
            int counter = 1 ;
        Start:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            if (persoane.Count() > 0)
            {
                Console.WriteLine("Legend:");
                Console.WriteLine("c - Create new person");
                Console.WriteLine($"1-{persoane.Count()} - Select agenda");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Agendas:");
                Console.BackgroundColor = ConsoleColor.Black;
                foreach (Persoana pers in persoane)
                {
                    Console.WriteLine(counter +". "+pers);
                    counter++;
                }
                counter = 1;
            }
            else
            {
                Console.WriteLine("There are no users with an agenda. Press 'c' to create one. ");
                
            }
            Console.ForegroundColor = ConsoleColor.White;
            input = Console.ReadLine();
            try{
            if (input=="c")
            {
                Console.Write("Enter a name:");
                nume = Console.ReadLine();
                persoane.Add(new Persoana() { nume = nume });
            }
            else
            if (Convert.ToInt32(input)> 0 && Convert.ToInt32(input)<=persoane.Count())
            {
                Console.Clear();
                Console.WriteLine(persoane[Convert.ToInt32(input)-1].nume);
                Console.WriteLine("Legend:");
                Console.WriteLine("c - Create new activity");
                Console.WriteLine("b - Go back to agenda list");
                Console.WriteLine("");
                int index=Convert.ToInt32(input);
                if(persoane[index-1].acts.Count>0){
                    ShowAgenda(index-1);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Again:
                input=Console.ReadLine();
                if(input=="b")
                {
                    goto Start;    
                }
                else if(input=="c")
                {
                    AddActivity(index-1);
                }
                else
                {
                    Console.WriteLine("Not valid");
                    goto Again;
                }

            }
            }
            catch(System.FormatException){
                Console.WriteLine("Invalid input");
            }
            
            goto Start;
            //AutoRead();

            
        }

        private static void ShowAgenda(int input)
        {
            persoane[Convert.ToInt32(input)].ShowAgenda();
        }


        private static void AddActivity(int index)
        {
            persoane[Convert.ToInt32(index)].AddActivity();
        }
        
    }
}
