namespace VagabondAPI.GlobalMiddleware
{
    public class DestinationNotFound : Exception
    {
        public DestinationNotFound(int id)
            : base($"The destination with ID {id} was not found.") { }
    }
}