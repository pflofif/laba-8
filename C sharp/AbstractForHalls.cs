namespace C_sharp
{
    interface IHall
    {
        double CostOfAllTicketsInThisOperationForConcreteClient { get; set; }
        string NameOfHall { get; }
        //void DisplaySeats();
        string BueNewSeat();
    }
    abstract class AbstractHall : IHall
    {
        protected AbstractHall(string nameOfHall, double baseCost, int countSeats)
        {
            NameOfHall = nameOfHall;
            CostOfOneTicket = baseCost;
            CountOfSeat = countSeats;
        }

        protected int CountOfSeat { get; set; }
        protected double CostOfOneTicket { get; set; }

        public double CostOfAllTicketsInThisOperationForConcreteClient { get; set; }
        public string NameOfHall { get; set; }
        public abstract override string ToString();
        public abstract string BueNewSeat();
    }
}