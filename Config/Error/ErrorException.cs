namespace TesteVagaDevPleno.Config.Error
{
    public class ErrorException : Exception
    {
        public Dictionary<string, Object> Error { get; set; }

        public ErrorException(string message, int statusCode) : base(message)
        {
            Error = new Dictionary<string, object>()
        {
            { "status", statusCode },
            { "title", message},
        };

        }
    }
}