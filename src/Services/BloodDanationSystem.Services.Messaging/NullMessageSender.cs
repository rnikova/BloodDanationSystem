namespace BloodDanationSystem.Services.Messaging
{
    using System.Threading.Tasks;

    public class NullMessageSender : IEmailSender
    {
        public Task SendEmailAsync(
            string to,
            string subject,
            byte[] attachment = null)
        {
            return Task.CompletedTask;
        }

        public Task SendEmailConfirmationAsync(string to, string subject, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
