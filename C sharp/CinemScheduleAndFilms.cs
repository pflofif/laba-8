using C_sharp.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using C_sharp.Factory;

namespace C_sharp
{
    internal class CinemaSchedule : AllFilms
    {
        private int openCasa = 5, closeCasa = 23;
        private Dictionary<int, IHall> scheduler = new Dictionary<int, IHall>();
        private void ScheduleOfFilms()
        {
            DateTime todayDay = DateTime.Today;
            DateTime movieScheduleForTheDay = new DateTime(todayDay.Year, todayDay.Month, todayDay.Day, openCasa, 0, 0);

            double countOfHoursPerDay = 0;
            int indexOfHall = 1, j = 0;
            while (true)
            {
                foreach (var fl in FilmsList)
                {
                    double durationOfFilm = fl.duration;

                    countOfHoursPerDay += durationOfFilm;
                    if (countOfHoursPerDay > closeCasa - openCasa) return;

                    var info = $"{fl.nameOfFilm} : start - {movieScheduleForTheDay.ToLongTimeString()}," +
                                  $" end - {movieScheduleForTheDay.AddMinutes(durationOfFilm * 60).ToLongTimeString()}\n";

                    scheduler.Add(indexOfHall++, CreateConcreteHall(RandomHall(), info, FilmsList[j++].baseCost).CreateHall());
                    movieScheduleForTheDay = movieScheduleForTheDay.AddMinutes(durationOfFilm * 60 + 15);
                }
                j = 0;
            }
        } //Створення Конкретного списку MovieTheatre
        private int RandomHall() => new Random(Guid.NewGuid().GetHashCode()).Next(1, 4);
        public void PrintScheduler()
        {
            if(scheduler.Count == 0 || scheduler == null) ScheduleOfFilms();

            foreach (KeyValuePair<int, IHall> i in scheduler)
            {
                Console.WriteLine($"{i.Key} : {i.Value.NameOfHall}");
            }
        }
        public IHall ConcreteMovieTheatreAndTime()
        {
            PrintScheduler();
            Console.WriteLine("CHOOSE ONE FILM AND HALL TOU WANT:");
            int choose;
            do
            {
                choose = Extensions.EnterNumber();
            } while (choose > scheduler.Count || choose == 0);

            return scheduler[choose];
        }
        private HallFactory CreateConcreteHall(int num, string nameAndInfo , int cost)
        {
            switch (num)
            {
                case 1:
                    return new HallSquareFactory(nameAndInfo, cost);
                case 2:
                    return new HallDiagonalFactory(nameAndInfo, cost);
                case 3:
                    return new HallRectangleFactory(nameAndInfo, cost);
            }
            return null;
        }
    }
    internal class AllFilms
    {
        protected List<Film> FilmsList = new List<Film>();
        public AllFilms()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Flims.txt");
            var json = File.ReadAllText(path);
            Film[] film = Newtonsoft.Json.JsonConvert.DeserializeObject<Film[]>(json);
            foreach (var fl in film)
            {
                FilmsList.Add(fl);
            }
        }
        public void ListOfAllMovies()
        {
            foreach (var fl in FilmsList)
            {
                Console.WriteLine(fl.ToFormatedString());
            }
        }
    }
    public class Film
    {
        [Newtonsoft.Json.JsonProperty("nameOfFilm")]
        public string nameOfFilm { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public double duration { get; set; }

        [Newtonsoft.Json.JsonProperty("descriptionOfTheFilm")]
        public string descriptionOfTheFilm { get; set; }

        [Newtonsoft.Json.JsonProperty("baseCost")]
        public int baseCost { get; set; }

        public Film() { }
    }
}
