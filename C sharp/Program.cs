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

            //RegularViewer vrRegularViewer = new RegularViewer();
            //vrRegularViewer.CostForAllTickets = 400;
            //vrRegularViewer.PrintAllInfoAboutClient();

            //Viewer vie = vrRegularViewer;
            //vie.Discount();

            //vie.PrintAllInfoAboutClient();

            //viwer2 = viewer;
            //viwer2.PrintAllInfoAboutClient();

            var schedule = new CinemaSchedule();

            var caseTick = new FilmCase(ref schedule);

            caseTick.CaseOfTicket();

            // var cinemacircle = new CircleCinema("dfgh", 100);
            // CircleCinema vff = new CinemaHallInBuilding("fgg", 100);
            // cinemacircle.DisplaySeats();
            //// vff.DisplaySeats();
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
