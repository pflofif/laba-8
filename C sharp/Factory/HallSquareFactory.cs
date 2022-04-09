using C_sharp.Halls;

namespace C_sharp.Factory
{
    class HallSquareFactory: HallFactory
    {
        private string nameOfHall;
        private int costOfOneTicket;
        private int countOfSeats;
        private int seatsInRow;

        public HallSquareFactory(string nameOfHall, int costOfOneTicket, int countOfSeats = 42, int seatsInRow = 6)
        {
            this.nameOfHall = nameOfHall;
            this.costOfOneTicket = costOfOneTicket;
            this.countOfSeats = countOfSeats;
            this.seatsInRow = seatsInRow;
        }

        public override IHall CreateHall()
        {
            return new SquareHall(nameOfHall, costOfOneTicket, countOfSeats, seatsInRow);
        }
    }
}
