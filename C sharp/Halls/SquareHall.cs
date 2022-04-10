using System;
using System.Collections.Generic;
using C_sharp.Properties;

namespace C_sharp.Halls
{
    sealed class SquareHall : AbstractHall
    {
        private int SeatsInRow { get; }
        private Dictionary<int, string> soldTickets = new Dictionary<int, string>();

        public SquareHall(string nameOfHall, double baseCost, int countSeats = 42, int seatsRow = 6)
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
}