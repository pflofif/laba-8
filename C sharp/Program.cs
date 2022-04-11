using System;
using System.Collections;
using System.Collections.Generic;
using C_sharp.Halls;
using C_sharp.Properties;

namespace C_sharp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO CINEMA CASE\n");

            #region TaskFor10Laba
            //For10Lab a = new For10Lab();
            //for (int i = 0; i < 20; i += 2)
            //{
            //    a[i] = new Viewer($"tick + {i}");
            //}

            //a[45] = 456;
            //a[33] = new DiagonalHall("hgf", 100);

            //Console.WriteLine($"{a[78]}{a[45]}{a[33]}");

            //for (int i = 0; i < 20; i += 2)
            //{
            //    Console.WriteLine(a[i]);
            //}
            #endregion

            #region Task for Laba 8-9

            var schedule = new CinemaSchedule();

            var caseTick = new FilmCase(ref schedule);

            caseTick.CaseOfTicket();

            #endregion


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
