using System.ComponentModel.DataAnnotations;

namespace triluatsoft.tls.Web.Models.Account
{
    public class SendEmailActivationLinkViewModel
    {
        public string TenancyName { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}