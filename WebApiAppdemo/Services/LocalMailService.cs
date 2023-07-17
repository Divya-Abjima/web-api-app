namespace WebApiAppdemo.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailto = string.Empty;
        private string _mailfrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailto = configuration["mailSettings:mailToAdress"]!;
            _mailfrom = configuration["mailSettings:mailFromAdress"]!;
        }
        public void Send(string message, string title)
        {
            Console.WriteLine($"Mail sent to {_mailto} from {_mailfrom} with" + nameof(LocalMailService));
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Message: {message}");
        }
    }

}