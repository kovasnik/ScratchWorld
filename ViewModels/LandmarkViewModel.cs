using ScratchWorld.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScratchWorld.ViewModels
{
    public class LandmarkViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Coordinates { get; set; }
        [Required]
        public int RegionId { get; set; }
        [Required]
        public bool IsShated { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
