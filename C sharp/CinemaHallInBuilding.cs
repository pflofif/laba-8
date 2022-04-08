using System;
using System.CodeDom;
using System.Collections.Generic;
using C_sharp.Properties;

namespace C_sharp
{
    interface ISeating
    {
        double CostOfAllTicketsInThisOperationForConcreteClient { get; set; }
        string NameOfHall { get; }
        void DisplaySeats();
        string BueNewSeat();
    }

    abstract class AbstractHall : ISeating
    {
        protected AbstractHall(string nameOfHall, double baseCost, int countSeats = 42)
        {
            NameOfHall = nameOfHall;
            CostOfOneTicket = baseCost;
            CountOfSeat = countSeats;
        }

        protected int CountOfSeat { get; set; }
        protected double CostOfOneTicket { get; set; }

        public double CostOfAllTicketsInThisOperationForConcreteClient { get; set; }
        public string NameOfHall { get; set; }
        public abstract void DisplaySeats();
        public abstract string BueNewSeat();
    }

    class CinemaHallInBuilding : AbstractHall
    {
        private int SeatsInRow { get; set; }
        private Dictionary<int, string> soldTickets = new Dictionary<int, string>();

        public CinemaHallInBuilding(string nameOfHall, double baseCost, int countSeats = 42, int seatsRow = 6)
            : base(nameOfHall, baseCost, countSeats)
        {
            SeatsInRow = seatsRow;
        }
        private double TicketPrice(int ticket)
        {
            if (ticket <= Math.Ceiling((decimal)CountOfSeat / SeatsInRow / 2) * SeatsInRow) return CostOfOneTicket;
            if (ticket > (Math.Ceiling((decimal)CountOfSeat / SeatsInRow) - 1) * SeatsInRow) return CostOfOneTicket * 2;
            return CostOfOneTicket * 1.5;
        }
        private int ChooseSeat()
        {
            int chooseSeat;
            do
            {
                chooseSeat = Extensions.EnterNumber();
            } while (chooseSeat > CountOfSeat || soldTickets.ContainsKey(chooseSeat));

            return chooseSeat;
        }
        public override void DisplaySeats()
        {
            int z = 1;
            for (int i = 0; i < CountOfSeat / SeatsInRow; i++, Console.WriteLine())
            {
                for (int j = 0; j < SeatsInRow; j++)
                {
                    if (soldTickets.ContainsKey(z)) Console.ForegroundColor = ConsoleColor.DarkGray;
                    else if (i < Math.Ceiling((decimal)CountOfSeat / SeatsInRow / 2)) Console.ForegroundColor = ConsoleColor.Green;
                    else if (i == CountOfSeat / SeatsInRow - 1) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.Blue;

                    Console.Write(z.ToString().PadRight(6));
                    z++;
                    Console.ResetColor();
                }
            }
        }
        public override string BueNewSeat()
        {
            Console.WriteLine("\n" + NameOfHall);
            string allSeats = "";
            while (true)
            {
                DisplaySeats();
                var choose = ChooseSeat();
                if (choose != 0)
                {
                    CostOfAllTicketsInThisOperationForConcreteClient += TicketPrice(choose);

                    allSeats += choose + " ";
                    soldTickets.Add(choose, $"The seats {choose} is already bue");
                }
                else
                {
                    try { return allSeats.Remove(allSeats.LastIndexOf(" ", StringComparison.Ordinal)); }
                    catch (ArgumentOutOfRangeException) { Console.WriteLine("Please choose 1 or more ticket"); }
                }
            }
        }
    }

    class CircleCinema : AbstractHall
    {
        public CircleCinema(string nameOfHall, double baseCost, int countSeats = 42) : base(nameOfHall, baseCost, countSeats) { }

        public override void DisplaySeats()
        {
            int z = 1, j = 1;
            CountOfSeat /= 2;
            while (CountOfSeat > 0)
            {
                for (int i = 0; i < z; i++)
                {
                    Console.Write(j.ToString().PadRight(3));
                    j++;
                }
                z++; Console.WriteLine();
                CountOfSeat-=2;
            }
        }

        public override string BueNewSeat()
        {
            throw new NotImplementedException();
        }

        //public static implicit operator CircleCinema(CinemaHallInBuilding v)
        //{
        //    v.DisplaySeats();
        //    return CinemaHallInBuilding();
        //}
    }
}