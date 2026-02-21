using MimeKit;
using MailKit.Net.Smtp;

namespace ThreeSEgypt.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _config;
        public EmailSender(EmailConfiguration config) { _config = config; }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_config.From));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };
            using var client = new SmtpClient();
            await client.ConnectAsync(_config.SmtpServer, _config.Port, MailKit.Security.SecureSocketOptions.Auto);
            if (!string.IsNullOrEmpty(_config.Username)) await client.AuthenticateAsync(_config.Username, _config.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
