using System.ComponentModel.DataAnnotations;

namespace ScratchWorld.ViewModels
{
    public class UserEditViewModel
    {
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }

    }
}