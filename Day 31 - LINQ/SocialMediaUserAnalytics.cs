using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class User
    {
        public int Id;
        public string Name;
        public string Country;
    }
    class Post
    {
        public int UserId;
        public int Likes;
    }

    internal class SocialMediaUserAnalytics
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };

            Console.WriteLine("Get top users by total likes");


            Console.WriteLine("\nGroup users by country");


            Console.WriteLine("\nList inactive users(no posts)");


            Console.WriteLine("\nCalculate average likes per post");

        }
    }
}
