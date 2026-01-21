using InnoteksoWeb.Models;
using innoteksoWebNew.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace InnoteksoWebNew.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmailService> _logger;
        private const string FORMSUBMIT_ENDPOINT = "https://formsubmit.co/peiso.innotekso@gmail.com";

        public EmailService(HttpClient httpClient, ILogger<EmailService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> SendQuoteRequestAsync(ContactModel contact)
        {
            try
            {
                _logger.LogInformation("Sending quote request via FormSubmit.co");

                var formData = new Dictionary<string, string>
                {
                    // FormSubmit.co special fields (start with _)
                    { "_subject", $"New Quote Request - {contact.ServiceType}" },
                    { "_template", "box" }, // Nice HTML template
                    { "_captcha", "false" }, // Set to "true" if you want captcha
                    
                    // Your data
                    { "name", $"{contact.FirstName} {contact.LastName}" },
                    { "first_name", contact.FirstName },
                    { "last_name", contact.LastName },
                    { "phone", contact.ContactNumber },
                    { "email", contact.Email },
                    { "service_type", contact.ServiceType ?? "Not specified" },
                    { "message", contact.Message ?? "" }
                };

                var content = new FormUrlEncodedContent(formData);
                var response = await _httpClient.PostAsync(FORMSUBMIT_ENDPOINT, content);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Quote request sent successfully");
                    return true;
                }
                else
                {
                    _logger.LogWarning($"FormSubmit returned status: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending quote request via FormSubmit.co");
                return false;
            }
        }

        public async Task<bool> SendCustomQuoteRequestAsync(CustomQuoteModel customQuote)
        {
            try
            {
                _logger.LogInformation("Sending custom quote request via FormSubmit.co");

                var selectedOptions = string.Join(", ", customQuote.SelectedOptions);

                var formData = new Dictionary<string, string>
                {
                    // FormSubmit.co special fields
                    { "_subject", "Custom Solution Quote Request - Innotekso" },
                    { "_template", "box" },
                    { "_captcha", "false" },
                    
                    // Your data
                    { "name", $"{customQuote.FirstName} {customQuote.LastName}" },
                    { "first_name", customQuote.FirstName },
                    { "last_name", customQuote.LastName },
                    { "phone", customQuote.ContactNumber },
                    { "email", customQuote.Email },
                    { "budget_range", customQuote.BudgetRange ?? "Not specified" },
                    { "timeline", customQuote.Timeline ?? "Not specified" },
                    { "interested_in", selectedOptions },
                    { "project_description", customQuote.ProjectDescription ?? "" }
                };

                var content = new FormUrlEncodedContent(formData);
                var response = await _httpClient.PostAsync(FORMSUBMIT_ENDPOINT, content);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Custom quote request sent successfully");
                    return true;
                }
                else
                {
                    _logger.LogWarning($"FormSubmit returned status: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending custom quote request via FormSubmit.co");
                return false;
            }
        }
    }
}