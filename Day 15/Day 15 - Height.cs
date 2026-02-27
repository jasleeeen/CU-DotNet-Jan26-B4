namespace Height
{
    class Height
    {
        public int Feet { get; set; }
        public double Inches { get; set; }
        public Height()
        {
            Feet = 0;
            Inches = 0.0;
        }
        public Height(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }
        public Height AddHeights(Height h2)
        {
            int totalFeet = this.Feet + h2.Feet;
            double totalInches = this.Inches + h2.Inches;
            if (totalInches >= 12)
            {
                int extraFeet = (int)(totalInches / 12);
                totalFeet += extraFeet;
                totalInches = totalInches % 12;
            }
            Height result = new Height(totalFeet, totalInches);
            return result;
        }
        public override string ToString()
        {
            return ($"Height - {Feet} feet {Inches:F1} inches");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter height for person 1: ");
            string input1 = Console.ReadLine();
            string[] parts = input1.Split(' ');
            int feet1 = int.Parse(parts[0]);
            double inches1 = double.Parse(parts[2]);
            Height person1 = new Height(feet1, inches1);

            Console.Write("Enter height for person 2: ");
            string input2 = Console.ReadLine();
            parts = input2.Split(' ');
            int feet2 = int.Parse(parts[0]);
            double inches2 = double.Parse(parts[2]);
            Height person2 = new Height(feet2, inches2);
            Height totalHeight = person1.AddHeights(person2);

            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());
            Console.WriteLine(totalHeight.ToString());
        }
    }
}