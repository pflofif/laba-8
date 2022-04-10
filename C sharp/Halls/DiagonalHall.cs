using System;
using System.Collections.Generic;
using C_sharp.Properties;

namespace C_sharp.Halls
{
    sealed class DiagonalHall : AbstractHall
    {
        private Dictionary<int, string> soldTickets = new Dictionary<int, string>();

        public DiagonalHall(string nameOfHall, double baseCost, int countSeats) : base(nameOfHall, baseCost, countSeats) { }
        private int ChooseSeat()
        {
            int chooseSeat;
            do
            {
                chooseSeat = Extensions.EnterNumber();
            } while (chooseSeat > CountOfSeat || soldTickets.ContainsKey(chooseSeat));

            return chooseSeat;
        }
        private double TicketPrice(int ticket)
        {
            if (ticket % 2 == 0) return CostOfOneTicket;
            return CostOfOneTicket * 2;
        }
        public override void DisplaySeats()
        {
            int z = 1, j = 1;
            var TEMPCountOfSeat = CountOfSeat;

            while (TEMPCountOfSeat > 0)
            {
                for (int i = 0; i < z; i++)
                {
                    if (--TEMPCountOfSeat < 0)
                    {
                        Console.WriteLine(); return;
                    }

                    if (soldTickets.ContainsKey(j)) Console.ForegroundColor = ConsoleColor.DarkGray;
                    else Console.ForegroundColor = j % 2 == 0 ? ConsoleColor.Cyan : ConsoleColor.Magenta;

                    Console.Write(j.ToString().PadRight(6));

                    Console.ResetColor();
                    j++;
                }
                z++; Console.WriteLine();
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