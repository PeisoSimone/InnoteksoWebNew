using InnoteksoWeb.Models;
using innoteksoWebNew.Models;

namespace InnoteksoWebNew.Services
{
    public interface IEmailService
    {
        Task<bool> SendQuoteRequestAsync(ContactModel contact);
        Task<bool> SendCustomQuoteRequestAsync(CustomQuoteModel customQuote);
    }
}