using System;
namespace Agenda_OOP
{
    internal class Activities
    {
        public string name;
        public string description;
        public DateTime start = new DateTime();
        public DateTime finish = new DateTime();
        public string participants;

        public Activities()
        {
        }
    }
}