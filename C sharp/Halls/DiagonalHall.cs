using System;
using System.Collections.Generic;
using C_sharp.Properties;

namespace C_sharp.Halls
{
    sealed class DiagonalHall : AbstractHall
    {
        private Dictionary<int, string> soldTickets = new Dictionary<int, string>();

        public DiagonalHall(string nameOfHall, double baseCost, int countSeats = 66) : base(nameOfHall, baseCost, countSeats) { }
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
        public override string ToString()
        {
            int numberOfCurrentRow = 1, numberOfCurrentSeat = 1;
            var tempCountOfSeat = CountOfSeat;

            while (tempCountOfSeat > 0)
            {
                for (int i = 0; i < numberOfCurrentRow; i++)
                {
                    if (--tempCountOfSeat < 0)
                    {
                        Console.WriteLine(); return string.Empty;
                    }

                    if (soldTickets.ContainsKey(numberOfCurrentSeat)) Console.ForegroundColor = ConsoleColor.DarkGray;
                    else Console.ForegroundColor = numberOfCurrentSeat % 2 == 0 ? ConsoleColor.Cyan : ConsoleColor.Magenta;

                    Console.Write(numberOfCurrentSeat.ToString().PadRight(6));

                    Console.ResetColor();
                    numberOfCurrentSeat++;
                }
                numberOfCurrentRow++; Console.WriteLine();
            }

            return string.Empty;
        }
        public override string BueNewSeat()
        {
            Console.WriteLine("\n" + NameOfHall);
            string allSeats = "";
            while (true)
            {
                ToString();
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