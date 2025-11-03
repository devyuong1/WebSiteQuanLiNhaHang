using Microsoft.Extensions.Options;
using MimeKit;

using UngDungQuanLiNhaHang.Models;
using MailKit.Net.Smtp;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class EmailService : IEmailService  {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> options) {
            _settings = options.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body) {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.DisplayName, _settings.UserName));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            // HTML body (có thể là plain text)
            message.Body = new TextPart("html") {
                Text = body
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_settings.Host, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.UserName, _settings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
