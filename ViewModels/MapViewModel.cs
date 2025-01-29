using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchWorld.ViewModels
{
    public class MapViewModel
    {
        public string UserId { get; set; }
        public int RegionId { get; set; } // for RegionSettings table
        public int? ColorPalette { get; set; }
        public int? Status { get; set; }
        public string Name { get; set; }
        public string UkrName { get; set; }
        public string Coordinates { get; set; }
    }
}
