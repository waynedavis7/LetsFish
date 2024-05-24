using System.ComponentModel.DataAnnotations;

namespace LetsFish.Shared.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}