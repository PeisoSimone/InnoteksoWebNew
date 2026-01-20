using innoteksoWebNew.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using InnoteksoWebNew.Services;
using InnoteksoWeb.Models;

namespace innoteksoWebNew.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> SendQuoteRequestAsync(ContactModel contact)
        {
            try
            {
                var subject = $"New Quote Request - {contact.ServiceType}";
                var body = BuildQuoteRequestEmail(contact);

                return await SendEmailAsync(subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending quote request email");
                return false;
            }
        }

        public async Task<bool> SendCustomQuoteRequestAsync(CustomQuoteModel customQuote)
        {
            try
            {
                var subject = "New Custom Solution Quote Request";
                var body = BuildCustomQuoteEmail(customQuote);

                return await SendEmailAsync(subject, body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending custom quote request email");
                return false;
            }
        }

        private async Task<bool> SendEmailAsync(string subject, string body)
        {
            try
            {
                // Get email settings from configuration
                var smtpHost = _configuration["Email:SmtpHost"];
                var smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
                var smtpUsername = _configuration["Email:SmtpUsername"];
                var smtpPassword = _configuration["Email:SmtpPassword"];
                var fromEmail = _configuration["Email:FromEmail"];
                var toEmail = _configuration["Email:ToEmail"];

                using var smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail, "Innotekso Website"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                return false;
            }
        }

        private string BuildQuoteRequestEmail(ContactModel contact)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #0066FF 0%, #00D9FF 100%); color: white; padding: 20px; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 20px; border-radius: 0 0 10px 10px; }}
        .field {{ margin-bottom: 15px; }}
        .label {{ font-weight: bold; color: #0066FF; }}
        .value {{ margin-left: 10px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>New Quote Request from Innotekso Website</h2>
        </div>
        <div class='content'>
            <div class='field'>
                <span class='label'>Name:</span>
                <span class='value'>{contact.FirstName} {contact.LastName}</span>
            </div>
            <div class='field'>
                <span class='label'>Contact Number:</span>
                <span class='value'>{contact.ContactNumber}</span>
            </div>
            <div class='field'>
                <span class='label'>Email:</span>
                <span class='value'>{contact.Email}</span>
            </div>
            <div class='field'>
                <span class='label'>Service Interested In:</span>
                <span class='value'>{contact.ServiceType}</span>
            </div>
            <div class='field'>
                <span class='label'>Message:</span>
                <div style='background: white; padding: 15px; border-radius: 5px; margin-top: 10px;'>
                    {contact.Message.Replace("\n", "<br>")}
                </div>
            </div>
        </div>
    </div>
</body>
</html>";
        }

        private string BuildCustomQuoteEmail(CustomQuoteModel customQuote)
        {
            var selectedOptionsHtml = string.Join("<br>", 
                customQuote.SelectedOptions.Select(o => $"• {o}"));

            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #0066FF 0%, #00D9FF 100%); color: white; padding: 20px; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 20px; border-radius: 0 0 10px 10px; }}
        .field {{ margin-bottom: 15px; }}
        .label {{ font-weight: bold; color: #0066FF; }}
        .value {{ margin-left: 10px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>Custom Solution Quote Request</h2>
        </div>
        <div class='content'>
            <div class='field'>
                <span class='label'>Name:</span>
                <span class='value'>{customQuote.FirstName} {customQuote.LastName}</span>
            </div>
            <div class='field'>
                <span class='label'>Contact Number:</span>
                <span class='value'>{customQuote.ContactNumber}</span>
            </div>
            <div class='field'>
                <span class='label'>Email:</span>
                <span class='value'>{customQuote.Email}</span>
            </div>
            <div class='field'>
                <span class='label'>Budget Range:</span>
                <span class='value'>{customQuote.BudgetRange}</span>
            </div>
            <div class='field'>
                <span class='label'>Timeline:</span>
                <span class='value'>{customQuote.Timeline}</span>
            </div>
            <div class='field'>
                <span class='label'>Selected Options:</span>
                <div style='background: white; padding: 15px; border-radius: 5px; margin-top: 10px;'>
                    {selectedOptionsHtml}
                </div>
            </div>
            <div class='field'>
                <span class='label'>Project Description:</span>
                <div style='background: white; padding: 15px; border-radius: 5px; margin-top: 10px;'>
                    {customQuote.ProjectDescription.Replace("\n", "<br>")}
                </div>
            </div>
        </div>
    </div>
</body>
</html>";
        }
    }
}
