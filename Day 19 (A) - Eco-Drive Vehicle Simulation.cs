namespace ConsoleApp19Exer
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        protected Vehicle(string modelName)
        {
            ModelName = modelName;
        }
        abstract public void Move();
        virtual public void GetFuelStatus()
        {
            Console.WriteLine("Fuel level is stable.");
        }
    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string modelName) : base(modelName){        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }
        public override void GetFuelStatus()
        {
            Console.WriteLine($"{ModelName} battery is at 80%.");
        }
    }

    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string modelName) : base(modelName) { }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }
    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string modelName) : base(modelName) { }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }
        public override void GetFuelStatus()
        {
            base.GetFuelStatus();
            Console.WriteLine("Checking jet fuel reserves...");
        }
    }

    internal class EcoDriveVehicleSimulation
    {
        static void Main(string[] args)
        {
            ElectricCar car = new ElectricCar("ElectricCar");
            HeavyTruck truck = new HeavyTruck("HeavyTruck");
            CargoPlane plane = new CargoPlane("CargoPlane");

            Vehicle[] vehicles = new Vehicle[3];
            vehicles[0] = car;
            vehicles[1] = truck;
            vehicles[2] = plane;

            for (int i = 0; i < vehicles.Length; i++)
            {
                vehicles[i].Move();
                vehicles[i].GetFuelStatus();
                Console.WriteLine();
            }
        }
    }
}
