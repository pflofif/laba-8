using System;
using System.Collections.Generic;
using C_sharp.Properties;

namespace C_sharp.Halls
{
    class RectangleHall:AbstractHall

    {
        private Dictionary<int, string> soldTickets = new Dictionary<int, string>();
        private int SeatsInRow { get; }

        public RectangleHall(string nameOfHall, double baseCost, int countSeats = 42, int seatsInRow = 3) 
            : base(nameOfHall, baseCost, countSeats)
        {
            SeatsInRow = seatsInRow;
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
                    if (soldTickets.ContainsKey(z)) Console.ForegroundColor = ConsoleColor.White;
                    else if (i < Math.Ceiling((decimal)CountOfSeat / SeatsInRow / 2)) Console.ForegroundColor = ConsoleColor.DarkBlue;
                    else if (i == CountOfSeat / SeatsInRow - 1) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    else Console.ForegroundColor = ConsoleColor.DarkYellow;

                    Console.Write(z.ToString().PadRight(6));
                    z++;
                    Console.ResetColor();
                }
            }
        }
        private double TicketPrice(int ticket)
        {
            if (ticket <= Math.Ceiling((decimal)CountOfSeat / SeatsInRow / 2) * SeatsInRow) return CostOfOneTicket;
            if (ticket > (Math.Ceiling((decimal)CountOfSeat / SeatsInRow) - 1) * SeatsInRow) return CostOfOneTicket * 2;
            return CostOfOneTicket * 1.5;
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