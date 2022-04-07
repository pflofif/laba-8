﻿using System;
using System.Collections.Generic;

namespace C_sharp
{
    interface IClient
    {
        string NameAndSurnameOfClient { get; }
        int CountOfTickets { get; }
        void BueNewTicket(ISeating hallSeating);
        void PrintAllInfoAboutClient();
    }
    class Viewer:IClient
    {
        private List<Ticket> tickets = new List<Ticket>();
        private double costForAllTickets;
        private static int _howMuchAnonim = 0;
        private const string anonimName = "Anonim Ticket ";

        public string NameAndSurnameOfClient { get; }
        public double CostForAllTickets { get => costForAllTickets; set => costForAllTickets = value; }
        public int CountOfTickets { get => tickets.Count; }

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
        public void BueNewTicket(ISeating hallSeating)
        {
            string []allSeats = hallSeating.BueNewSeat().Split(' ');

            CostForAllTickets += hallSeating.CostOfAllTicketsInThisOperationForConcreteClient;

            foreach(string i in allSeats)
            {
                tickets.Add(new Ticket(i, hallSeating.NameOfHall.Remove(hallSeating.NameOfHall.LastIndexOf("\n", StringComparison.Ordinal))));
            }
        }
        public void PrintAllInfoAboutClient()
        {
            Console.WriteLine($"\nname and surname of viewer:  {NameAndSurnameOfClient} ");
            foreach (var i in tickets)
            {
                i.PrintInfo();
            }
            Console.WriteLine($"{NameAndSurnameOfClient} must pay : {CostForAllTickets} dollars!!!!!(please)\n");
        }
        public virtual void Discount() { costForAllTickets *= 1; }
    }
    class RegularViewer : Viewer
    {
        public RegularViewer(){}

        public override void Discount()
        {
            CostForAllTickets *= 0.5;
        }
    }

    //class Grid
    //{
    //    private int sub, det;

    //    //int getsub()
    //    //{
    //    //    return sub;}
    //    //int getdet()
    //    //{
    //    //    return det;
    //    //}
    //    public Grid(int sub, int det)
    //    {
    //        this.sub = sub;
    //        this.det = det;
    //    }
    //    public Grid(){}
    //    Grid plusss(Grid num)
    //    {
    //        Grid smt = new Grid(this.sub + num.sub, this.det + num.det);
    //        return smt;
    //    }
    //}

}