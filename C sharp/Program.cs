using System;
using System.CodeDom;

namespace C_sharp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO CINEMA CASE\n");

            //var hall = new CinemaSchedule().ConcreteMovieTheatreAndTime();
            //var viewer = new Viewer();

            Viewer vie = new RegularViewer();
            vie.CostForAllTickets = 900;
            vie.Discount();
            vie.PrintAllInfoAboutClient();
            //var viwer2 = new Viewer();
            //viewer.PrintAllInfoAboutClient();
            //viewer.BueNewTicket(hall);
            //viewer.PrintAllInfoAboutClient();

            //viwer2 = viewer;
            //viwer2.PrintAllInfoAboutClient();

            //var schedule = new CinemaSchedule();

            //var caseTick = new FilmCase(ref schedule);

            //caseTick.CaseOfTicket();

            Console.Write("enter any key to close!");
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
