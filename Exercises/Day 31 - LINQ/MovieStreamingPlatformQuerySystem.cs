using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class Movie 
    { 
        public string Title; 
        public string Genre; 
        public double Rating; 
        public int Year; 
    }
    internal class MovieStreamingPlatformQuerySystem
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            Console.WriteLine("Filter movies with rating > 8");
            var movieRating = movies.Where(m => m.Rating > 8);
            foreach (var item in movieRating)
            {
                Console.WriteLine(item.Title + " " + item.Rating);
            }

            Console.WriteLine("\nGroup movies by Genre and get average rating");
            var genreAvgRating = movies.GroupBy(m=>m.Genre).Select(m => new { Genre = m.Key, Avg = m.Average(s => s.Rating) }); ;
            foreach (var item in genreAvgRating)
            {
                Console.WriteLine(item.Genre + " " + item.Avg);
            }

            Console.WriteLine("\nFind latest movie per Genre");
            var latestMoviePerGenre = movies.GroupBy(m=>m.Genre).Select(g => g.OrderByDescending(m => m.Year).First());
            foreach (var item in latestMoviePerGenre)
            {
                Console.WriteLine(item.Title + " " + item.Year);
            }

            Console.WriteLine("\nGet top 5 highest-rated movies");
            var highestRatedMovie = movies.OrderByDescending(m => m.Rating).Take(5);
            foreach (var item in highestRatedMovie)
            {
                Console.WriteLine(item.Title + " " + item.Rating);
            }
        }
    }
}
