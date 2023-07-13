namespace WebApiAppdemo.Services
{
    public interface IMailService
    {
        void Send(string message, string title);
    }
}