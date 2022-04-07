using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp.Properties
{
    public static class Extensions
    {
        public static string ToFormatedString(this Film film)
        {
            return
                $"Film name: {film.nameOfFilm}\nduration: {film.duration} hours\ndescription Of The Film: {film.descriptionOfTheFilm}\nbase Cost: {film.baseCost}\n";
        }
        public static int EnterNumber()
        {
            int num;
            do
            {
                try
                {
                    Console.Write("Please enter your choice: ");
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    num = 0;
                }
            } while (num < 0);
            return num;
        }
    }
}
