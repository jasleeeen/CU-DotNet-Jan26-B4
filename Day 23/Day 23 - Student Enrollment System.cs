namespace Student_Enrollment_System
{
    internal class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string message) : base(message) { }
    }

    internal class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string message) : base(message) { }
    }
    internal class Program
    {
        public static void PrintExcDet(Exception ex)
        {
            Console.WriteLine($"Message :  {ex.Message} \nStack Trace : {ex.StackTrace}");
        }
        public static void DivFunc()
        {
            try 
            {
                Console.Write("Enter Number 1: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter Number 2: ");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine($"Result : {a/b}");
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine($"The user attempted to divide a number by 0.");
                PrintExcDet(ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Exception occured.");
                PrintExcDet(ex);
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }
        }

        public static void ConvertToInt()
        {
            try
            {
                Console.Write("Enter a number: ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine($"Converted Number: {num}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number format entered.");
                PrintExcDet(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception occured.");
                PrintExcDet(ex);
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }
        }

        public static void ArrayIndex()
        {
            try
            {
                Console.WriteLine("Enter number of elements: ");
                int num = int.Parse(Console.ReadLine());
                int[] arr = new int[num];
                Console.Write("Enter an array: ");
                for (int i = 0; i < num; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine($"Value : {arr[index]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Array index not present.");
                PrintExcDet(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception occured.");
                PrintExcDet(ex);
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }
        }

        public static void StudentValidation()
        {
            string name;
            int age;
            while (true)
            {
                try
                {
                    Console.Write("Enter Student Name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                        throw new InvalidStudentNameException("Student name cannot be empty.");
                    foreach (char c in name)
                    {
                        if (!char.IsLetter(c) && c != ' ')
                            throw new InvalidStudentNameException(
                                "Student name must contain only alphabets.");
                    }
                    break;
                }
                catch (InvalidStudentNameException ex)
                {
                    PrintExcDet(ex);
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Enter Student Age: ");
                    age = int.Parse(Console.ReadLine());
                    if (age < 18 || age > 60)
                        throw new InvalidStudentAgeException(
                            "Student age should be between 18 and 60.");
                    break; 
                }
                catch (InvalidStudentAgeException ex)
                {
                    PrintExcDet(ex);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Age must be a number.");
                    PrintExcDet(ex);
                }
            }
            Console.WriteLine("Student enrolled successfully.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Exception Handling");
            Console.WriteLine("Divide by 0");
            DivFunc();
            Console.WriteLine();
            Console.WriteLine("Convert to Integer");
            ConvertToInt();
            Console.WriteLine();
            Console.WriteLine("Array Index Out of Bounds");
            ArrayIndex();
            Console.WriteLine();
            Console.WriteLine("Student Name, Age Validation");
            StudentValidation();
            Console.WriteLine();
        }
    }
}
