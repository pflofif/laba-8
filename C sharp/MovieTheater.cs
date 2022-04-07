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
    class MovieTheater : ISeating
    {
        private int countOfSeat;
        private int seatsInRow;
        private double baseCost;
        private Dictionary<int, string> soldTickets = new Dictionary<int, string>();

        private double TicketPrice(int ticket)
        {
            if (ticket <= Math.Ceiling((decimal) countOfSeat / seatsInRow / 2) * seatsInRow) return baseCost;
            if (ticket > (Math.Ceiling((decimal)countOfSeat / seatsInRow) - 1) * seatsInRow) return baseCost * 2;
            return baseCost * 1.5;
        }
        public MovieTheater(string nameOfHall, double baseCost, int countSeats = 42, int seatsRow = 6)
        {
            countOfSeat = countSeats;
            seatsInRow = seatsRow;
            this.baseCost = baseCost;
            this.NameOfHall = nameOfHall;
        }
        private int ChooseSeat()
        {
            int chooseSeat;
            do
            {
                chooseSeat = Extensions.EnterNumber();
            } while (chooseSeat > countOfSeat || soldTickets.ContainsKey(chooseSeat));

            return chooseSeat;
        }

        public void DisplaySeats()
        {
            int z = 1;
            for (int i = 0; i < countOfSeat / seatsInRow; i++, Console.WriteLine())
            {
                for (int j = 0; j < seatsInRow; j++)
                {
                    if (soldTickets.ContainsKey(z)) Console.ForegroundColor = ConsoleColor.DarkGray;
                    else if (i < Math.Ceiling((decimal)countOfSeat / seatsInRow / 2)) Console.ForegroundColor = ConsoleColor.Green;
                    else if (i == countOfSeat / seatsInRow - 1) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.Blue;

                    Console.Write(z.ToString().PadRight(6));
                    z++;
                    Console.ResetColor();
                }
                //Console.Write($"{i}");
                //Console.ResetColor();
            }
        }
        public string BueNewSeat()
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
        public string NameOfHall { get; }
        public double CostOfAllTicketsInThisOperationForConcreteClient { get; set; }
    }
}