using System.ComponentModel.DataAnnotations;

namespace ScratchWorld.ViewModels
{
    public class AddDataViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Age { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
