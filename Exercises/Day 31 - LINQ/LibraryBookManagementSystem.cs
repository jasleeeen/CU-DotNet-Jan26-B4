using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public int Year;
        public double Price;
    }
    internal class LibraryBookManagementSystem
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };
            Console.WriteLine("Find books published after 2015");
            var bookAfter2015 = books.Where(b => b.Year > 2015);
            foreach (var item in bookAfter2015)
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("\nGroup by Genre and count books");
            var groupByGenre = books.GroupBy(b => b.Genre).Select(b => new
            {
                Genre = b.Key,
                Count = b.Count()
            });
            foreach (var item in groupByGenre)
            {
                Console.WriteLine(item.Genre + " " + item.Count);
            }

            Console.WriteLine("\nGet most expensive book per Genre");
            var expBookPerGenre = books.GroupBy(b=>b.Genre).Select(g => g.OrderByDescending(b => b.Price).First());
            foreach (var item in expBookPerGenre)
            {
                Console.WriteLine($"{item.Genre} - {item.Title} : {item.Price}");
            }

            Console.WriteLine("\nReturn distinct authors list");
            var distinctAuthors = books.Select(e => e.Author).Distinct();
            foreach (var item in distinctAuthors)
            {
                Console.WriteLine(item);
            }

        }
    }
}
