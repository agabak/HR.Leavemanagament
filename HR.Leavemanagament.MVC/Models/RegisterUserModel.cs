using System.ComponentModel.DataAnnotations;

namespace HR.Leavemanagament.MVC.Models
{
    public class RegisterUserModel
    {
       [Required]
       [Display(Name = "First name")]
       [MaxLength(100)]
       public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Username")]
        [MaxLength(100)]
        public string UserName { get; set; }

       [Required]
       [EmailAddress]
       public string Email { get; set; }

        [Required]
        public string Password { get; set;  }
    }
}
