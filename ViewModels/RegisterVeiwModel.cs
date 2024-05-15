using System.ComponentModel.DataAnnotations;

namespace ScratchWorld.ViewModels
{
    public class RegisterVeiwModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Age { get; set;}

    }
}
