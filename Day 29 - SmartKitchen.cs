using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay27_01_DailyLogger
{
    public abstract class KitchenDevice
    {
        public string ModelName { get; set; }
        public int PowerConsumption { get; set; }
        public KitchenDevice(string modelName, int power)
        {
            ModelName = modelName;
            PowerConsumption = power;
        }
        public abstract void Cook();
        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No preheating required.");
        }
    }
    public interface ITimer
    {
        void SetTimer(int minutes);
    }
    public interface IWifiEnabled
    {
        void ConnectToWifi();
    }
    public class Microwave : KitchenDevice, ITimer
    {
        public Microwave(string modelName, int power) : base(modelName, power)
        {   }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} mins");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Cooking");
        }
    }

    public class ElectricOven : KitchenDevice, ITimer, IWifiEnabled
    {
        public ElectricOven(string modelName, int power) : base(modelName, power)
        {   }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} mins");
        }
        public void ConnectToWifi()
        {
            Console.WriteLine($"{ModelName}: Connected to WiFi");
        }
        public override void Preheat()
        {
            Console.WriteLine($"{ModelName}: Preheating");
        }

        public override void Cook()
        {
            Preheat();
            Console.WriteLine($"{ModelName}: Cooking");
        }
    }

    public class AirFryer : KitchenDevice
    {
        public AirFryer(string modelName, int power) : base(modelName, power)
        {   }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Cooking");
        }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            List<KitchenDevice> devices = new List<KitchenDevice>
            {
                new Microwave("ABC", 1200),
                new ElectricOven("DEF", 2500),
                new AirFryer("GHI", 1500)
            };
            foreach (var device in devices)
            {
                device.Cook();
                Console.WriteLine();
            }
            foreach (var device in devices)
            {
                if (device is IWifiEnabled wifiDevice) wifiDevice.ConnectToWifi();
                else Console.WriteLine($"{device.ModelName}: No WiFi capability.");
            }
        }
    }
}