using System.Threading.Tasks;

namespace MediHubSC.Web.Helper
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}