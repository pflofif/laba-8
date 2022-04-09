using System;

namespace C_sharp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO CINEMA CASE\n");

            var schedule = new CinemaSchedule();

            var caseTick = new FilmCase(ref schedule);

            caseTick.CaseOfTicket();

            Console.Write($"enter any key to close!");
            Console.ReadKey();
        }

    }
    class Ticket
    {
        private string nameOfFilmAndStartAndEnd;
        private string seat;
        public Ticket(string seat, string nameOfFilmAndStartAndEnd)
        {
            this.seat = seat;
            this.nameOfFilmAndStartAndEnd = nameOfFilmAndStartAndEnd;
        }
        public void PrintInfo()
        {
            Console.Write($"Movie - {nameOfFilmAndStartAndEnd} ; seat - {seat}\n");
        }
    }
}
