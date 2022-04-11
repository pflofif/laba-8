using System;
using System.Collections.Generic;

namespace C_sharp
{
    interface IClient
    {
        string NameAndSurnameOfClient { get; }
        int CountOfTickets { get; }
        void BueNewTicket(IHall hallHall);
        void Discount();
    }
    class Viewer:IClient
    {
        private List<Ticket> tickets = new List<Ticket>();
        private double costForAllTickets;
        private static int _howMuchAnonim = 0;
        private const string anonimName = "Anonim Ticket ";

        public string NameAndSurnameOfClient { get; }
        public double CostForAllTickets { get => costForAllTickets; set => costForAllTickets = value; }
        public int CountOfTickets => tickets.Count;

        public Viewer(string name = anonimName)
        {
            if (name == anonimName)
            {
                name += _howMuchAnonim++;
            }
            NameAndSurnameOfClient = name;
        }
        public Viewer(Viewer objViewer)
        {
            tickets = objViewer.tickets;
            costForAllTickets = objViewer.costForAllTickets;
            NameAndSurnameOfClient = objViewer.NameAndSurnameOfClient;
        }
        public void BueNewTicket(IHall hallHall)
        {
            string []allSeats = hallHall.BueNewSeat().Split(' ');

            CostForAllTickets += hallHall.CostOfAllTicketsInThisOperationForConcreteClient;

            foreach(string i in allSeats)
            {
                tickets.Add(new Ticket(i, hallHall.NameOfHall.Remove(hallHall.NameOfHall.LastIndexOf("\n", StringComparison.Ordinal))));
            }
        }
        public override string ToString()
        {
            Console.WriteLine($"\nname and surname of viewer:  {NameAndSurnameOfClient} ");
            foreach (var i in tickets)
            {
                i.PrintInfo();
            }
            Console.WriteLine($"{NameAndSurnameOfClient} must pay : {CostForAllTickets} dollars!!!!!(please)\n");
            return string.Empty;
        }
        public virtual void Discount() { costForAllTickets *= 1; }

    }
    class RegularViewer : Viewer
    {
        public RegularViewer(){}
        public override void Discount()
        {
            CostForAllTickets *= 0.75;
        }
    }

}