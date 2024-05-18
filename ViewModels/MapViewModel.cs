using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchWorld.ViewModels
{
    public class MapViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RegionId { get; set; }
        public int? ColorPalette { get; set; }
        public int? Status { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
    }
}
