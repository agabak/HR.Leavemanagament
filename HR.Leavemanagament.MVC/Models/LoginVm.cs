using System.ComponentModel.DataAnnotations;

namespace HR.Leavemanagament.MVC.Models
{
    public class LoginVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
