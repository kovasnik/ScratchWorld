using System.ComponentModel.DataAnnotations;

namespace ScratchWorld.ViewModels
{
    public class DetailViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
