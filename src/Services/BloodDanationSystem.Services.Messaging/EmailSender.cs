namespace BloodDanationSystem.Services.Messaging
{
    using System.Threading.Tasks;

    using MailKit.Net.Smtp;
    using MimeKit;

    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration emailConfiguration;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
        }

        public async Task SendEmailAsync(string to, string subject, byte[] attachment = null)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(this.emailConfiguration.From));
            emailMessage.To.Add(new MailboxAddress(to));
            emailMessage.Subject = subject;

            var builder = new BodyBuilder();
            builder.Attachments.Add("служебна бележка.jpeg", attachment, new ContentType("image", "jpeg"));

            emailMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(this.emailConfiguration.SmtpServer, this.emailConfiguration.Port, false);
                client.AuthenticationMechanisms.Remove("HOAUTH2");
                await client.AuthenticateAsync(this.emailConfiguration.UserName, this.emailConfiguration.Password);

                await client.SendAsync(emailMessage);
            }
        }

        public async Task SendEmailConfirmationAsync(string to, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(this.emailConfiguration.From));
            emailMessage.To.Add(new MailboxAddress(to));
            emailMessage.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = message;

            emailMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(this.emailConfiguration.SmtpServer, this.emailConfiguration.Port, false);
                client.AuthenticationMechanisms.Remove("HOAUTH2");
                await client.AuthenticateAsync(this.emailConfiguration.UserName, this.emailConfiguration.Password);

                await client.SendAsync(emailMessage);
            }
        }
    }
}
