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
        static void Main(string[] args)
        {
            //Asta este cea mai buna tema pe care am primit-o, serios :D
            List<Persoana> persoane = new List<Persoana>();
            string nume;
        Start:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Legend:");
            Console.WriteLine("C - Create new person");
            if (persoane.Count() > 0)
            {
                Console.WriteLine($"1-{persoane.Count()} - Select person");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Persoana pers in persoane)
                {
                    Console.WriteLine(pers);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            //AutoRead();
            nume = Console.ReadLine();
            persoane.Add(new Persoana() { nume = nume });
            goto Start;
        }

        private static void AutoRead()
        {
            StreamReader sr = new StreamReader("..\\..\\Persoane.txt");
            using (sr)
            {
                while (sr.Peek() > 0)
                {
                    string nume = sr.ReadLine();
                }
            }
        }
    }
}
