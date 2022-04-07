using C_sharp.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace C_sharp
{
    internal class CinemaSchedule : AllFilms
    {
        private int openCasa = 5, closeCasa = 23;
        //Всі MovieTheater спокійно можна замінити на ISeating
        private Dictionary<int, MovieTheater> scheduler = new Dictionary<int, MovieTheater>();
        private Dictionary<int, MovieTheater> ScheduleOfFilms()
        {
            DateTime todayDay = DateTime.Today;
            DateTime movieScheduleForTheDay = new DateTime(todayDay.Year, todayDay.Month, todayDay.Day, openCasa, 0, 0);

            double countOfHoursPerDay = 0;
            int i = 1,j = 0;
            while (true)
            {
                foreach (var fl in FilmsList)
                {
                    double durationOfFilm = fl.duration;

                    countOfHoursPerDay += durationOfFilm;
                    if (countOfHoursPerDay > closeCasa - openCasa)
                    {
                        return scheduler;
                    }
                    scheduler.Add(i++, new MovieTheater($"{fl.nameOfFilm} :" +
                        $" start - {movieScheduleForTheDay.ToLongTimeString()}, " +
                        $" end - {movieScheduleForTheDay.AddMinutes(durationOfFilm * 60).ToLongTimeString()}\n", FilmsList[j++].baseCost));

                    movieScheduleForTheDay = movieScheduleForTheDay.AddMinutes(durationOfFilm * 60 + 15);
                }
                j = 0;
            }
        } //Створення Конкретного списку MovieTheatre
        public void PrintScheduler()
        {
            if(scheduler.Count == 0 || scheduler == null) ScheduleOfFilms();

            foreach (KeyValuePair<int, MovieTheater> i in scheduler)
            {
                Console.WriteLine($"{i.Key} : {i.Value.NameOfHall}");
            }
        }
        public MovieTheater ConcreteMovieTheatreAndTime()
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
