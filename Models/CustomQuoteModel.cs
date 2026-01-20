using System.ComponentModel.DataAnnotations;

namespace InnoteksoWeb.Models
{
    public class CustomQuoteModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        public string BudgetRange { get; set; } = string.Empty;

        public string Timeline { get; set; } = string.Empty;

        public List<string> SelectedOptions { get; set; } = new();

        [Required(ErrorMessage = "Please describe your project")]
        [MinLength(20, ErrorMessage = "Please provide more details about your project (minimum 20 characters)")]
        public string ProjectDescription { get; set; } = string.Empty;
    }
}
