namespace WebApiAppdemo.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailto = string.Empty;
        private string _mailftom = string.Empty;

        public CloudMailService(IConfiguration configuration) 
        {
            _mailto = configuration["mailSettings:mailToAddress"]!;
            _mailftom = configuration["mailSettings:mailFromAddress"]!;
        }
        public void Send(string message, string title)
        {
            Console.WriteLine($"Mail sent to {_mailto} from {_mailftom} with " + nameof(CloudMailService));
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Message: {message}");
        }
    }
    
}
