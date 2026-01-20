using InnoteksoWeb.Models;

namespace InnoteksoWeb.Services
{
    public interface IEmailService
    {
        Task<bool> SendQuoteRequestAsync(ContactModel contact);
        Task<bool> SendCustomQuoteRequestAsync(CustomQuoteModel customQuote);
    }
}
