namespace AccountService.Helpers
{
    public class AccountNumberGenerator
    {
        public static string Generate(int id)
        {
            return $"SB-{DateTime.Now.Year}-{id.ToString("D6")}";
        }
    }
}
