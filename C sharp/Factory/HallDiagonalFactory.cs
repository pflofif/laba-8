using C_sharp.Halls;

namespace C_sharp.Factory
{
    class HallDiagonalFactory : HallFactory

    {
        private string nameOfHall;
        private int costOfOneTicket;
        private int countOfSeats;

        public HallDiagonalFactory(string nameOfHall, int costOfOneTicket, int countOfSeats = 42)
        {
            this.nameOfHall = nameOfHall;
            this.costOfOneTicket = costOfOneTicket;
            this.countOfSeats = countOfSeats;
        }
        public override IHall CreateHall()
        {
            return new DiagonalHall(nameOfHall, costOfOneTicket, countOfSeats);
        }
    }
}
