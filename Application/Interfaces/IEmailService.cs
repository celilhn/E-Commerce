
namespace Application.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string emailTo, string body, string subject);
    }
}
