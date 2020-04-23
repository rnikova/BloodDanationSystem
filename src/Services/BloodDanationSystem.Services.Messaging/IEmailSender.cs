namespace BloodDanationSystem.Services.Messaging
{
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(
            string to,
            string subject,
            byte[] attachment = null);

        Task SendEmailConfirmationAsync(
            string to,
            string subject,
            string message);
    }
}
