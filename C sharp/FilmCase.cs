using C_sharp.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace C_sharp
{
    abstract class AbstractCasa
    {
        protected List<IClient> clients = new List<IClient>();
        protected abstract void NewClient();
        protected abstract void PrintListOfClients();
        protected abstract void ClientBueTicketsForFilm();
        public abstract void CaseOfTicket();

    }
    class FilmCase : AbstractCasa
    {
        //private List<Viewer> clients = new List<Viewer>();
        private CinemaSchedule films;
        private enum Menu
        {
            End = 0, CreateClient, BueTicket, PrintInfoAboutClient, MovieScheduler, WatchSeatsInHall, PrintFilms, SortViewer
        }
        public FilmCase(ref CinemaSchedule films) => this.films = films;
        protected override void NewClient()
        {
            Console.WriteLine("Enter your name , if you dont want click 'enter': ");
            var nameAndSurnameOfNewClient = Console.ReadLine();
            if (nameAndSurnameOfNewClient != null && nameAndSurnameOfNewClient.Length == 0)
            {
                clients.Add(new Viewer());
                return;
            }
            clients.Add(new Viewer(nameAndSurnameOfNewClient));
        } //ЗАПОВНЮЄТЬСЯ КЛІЄНТАМИ НА ФІЛЬМ(КОНКРЕТНИМИ)

        //private void DiscountForRegularViewer()
        //{
        //    Console.WriteLine("DiscountForRegularViewer");
        //    var tempReg = new RegularViewer();
        //    RegularViewer tempRegularViewer = (RegularViewer)clients[0];

        //    tempRegularViewer.Discount();
        //    Console.WriteLine("ThIS PRSON HAS A DICOUNT: "); tempRegularViewer.PrintAllInfoAboutClient();
        //    return;

        //    Console.WriteLine("NO DICOUNT???");
        //}
        private void SortViewers()
        {
            Console.WriteLine("\nSORTED LIST OF VIEWERS:");
            var clientsComparer = new ClientsComparer();

            clients.Sort(clientsComparer);
            PrintListOfClients();
        }
        private IClient ConcreteViewer()
        {
            PrintListOfClients();
            int chooseClient;
            do
            {
                chooseClient = Extensions.EnterNumber();
            } while (chooseClient > clients.Count || chooseClient == 0);

            return clients[--chooseClient];
        }
        protected override void ClientBueTicketsForFilm()
        {
            if (clients.Count == 0)
            {
                Console.WriteLine("NO CLIENTS"); return;
            }

            Console.WriteLine("YOU INTO BUYING MENU:");

            ConcreteViewer().BueNewTicket(films.ConcreteMovieTheatreAndTime());
            Console.WriteLine("\nYOU SUCCESSFULLY BYE A TICKET");
        }
        protected override void PrintListOfClients()
        {
            int i = 1;
            foreach (var viewer in clients)
            {
                Console.WriteLine(i++ + ". " + viewer.NameAndSurnameOfClient + " ; count on tickets: " + viewer.CountOfTickets);
            }
            Console.WriteLine();
        }
        private void CreateJsonFileOfClients()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clients);
            var path = Path.Combine(Environment.CurrentDirectory, "Clients.txt");
            File.WriteAllText(path, json);
        }
        private int MenuOfCase()
        {
            Console.WriteLine($"\n{(int)Menu.End} - Exit and close the program\n" +
                              $"{(int)Menu.CreateClient} - create new Client\n" +
                              $"{(int)Menu.BueTicket} - Client bue a ticket\n" +
                              $"{(int)Menu.PrintInfoAboutClient} - All Info about Viewer\n" +
                              $"{(int)Menu.MovieScheduler} - See movie schedule\n" +
                              $"{(int)Menu.WatchSeatsInHall} - See situation at the hall\n" +
                              $"{(int)Menu.PrintFilms} - All films\n" +
                              $"{(int)Menu.SortViewer} - Sort Viewers");

            var choose = Extensions.EnterNumber();
            return choose;
        }
        public override void CaseOfTicket()
        {
            int choose;
            while ((choose = MenuOfCase()) != (int)Menu.End)
            {
                switch (choose)
                {
                    case (int)Menu.CreateClient:
                        NewClient();
                        break;
                    case (int)Menu.BueTicket:
                        ClientBueTicketsForFilm();
                        break;
                    case (int)Menu.PrintInfoAboutClient:
                        Console.WriteLine();
                        if (clients.Count == 0)
                        {
                            Console.WriteLine("NO CLIENTS"); break;
                        }
                        //ConcreteViewer().PrintAllInfoAboutClient();
                        var tempViewer = ConcreteViewer();
                        tempViewer.PrintAllInfoAboutClient();
                        break;
                    case (int)Menu.MovieScheduler:
                        films.PrintScheduler();
                        break;
                    case (int)Menu.WatchSeatsInHall:
                        var hall = films.ConcreteMovieTheatreAndTime();
                        hall.DisplaySeats();
                        break;
                    case (int)Menu.PrintFilms:
                        films.ListOfAllMovies();
                        break;
                    case (int)Menu.SortViewer:
                        if (clients.Count == 0)
                        {
                            Console.WriteLine("NO CLIENTS");
                            break;
                        }
                        SortViewers();
                        //DiscountForRegularViewer();
                        break;
                    default:
                        Console.WriteLine("Error choice");
                        break;
                }
            }
            CreateJsonFileOfClients();
        }
    }
}
