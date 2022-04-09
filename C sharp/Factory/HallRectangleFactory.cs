using C_sharp.Halls;

namespace C_sharp.Factory
{
    class HallRectangleFactory:HallFactory
    {
        private string nameOfHall;
        private int costOfOneTicket;
        private int countOfSeats;
        private int seatsInRow;

        public HallRectangleFactory(string nameOfHall, int costOfOneTicket, int countOfSeats = 42, int seatsInRow = 3)
        {
            this.nameOfHall = nameOfHall;
            this.costOfOneTicket = costOfOneTicket;
            this.countOfSeats = countOfSeats;
            this.seatsInRow = seatsInRow;
        }

        public override IHall CreateHall()
        {
            return new RectangleHall(nameOfHall, costOfOneTicket, countOfSeats, seatsInRow);
        }
    }
}
