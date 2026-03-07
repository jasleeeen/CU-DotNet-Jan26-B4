using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._1
{
    internal class GymBill
    {
        static double CalGym(bool tread, bool weight, bool zumba)
        {
            double bill = 1000.0;
            if (tread || weight || zumba)
            {
                if (tread) bill += 300;
                if (weight) bill += 500;
                if (zumba) bill += 250;
            }
            else
            {
                bill += 200;
            }
            bill += bill * 0.05;
            return bill;
        }
        static void Main(string[] args)
        {
            double total = CalGym(false, false, false);
            Console.WriteLine($"Gym Bill : {total:F2}");
        }
    }
}