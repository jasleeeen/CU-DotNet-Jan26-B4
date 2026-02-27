using System.ComponentModel.Design.Serialization;

namespace Application_Configuration_Tracker
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }
        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Static constructor executed");
        }
        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            IsInitialized = true;
            Environment = environment;
            AccessCount++;
        }
        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name: {ApplicationName}\nEnvironment: {Environment} \nAccess Count: {AccessCount} \nInitialization Status: {IsInitialized}";
        }
        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount = 0;
            AccessCount++;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.ApplicationName);
            Console.WriteLine();
            ApplicationConfig.Initialize("App", "Dev");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            Console.WriteLine();
            ApplicationConfig.Initialize("App34", "QA");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            Console.WriteLine();
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());


        }
    }
}
