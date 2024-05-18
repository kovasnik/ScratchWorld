using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchWorld.Models
{
    [Table("user_region", Schema = "public")]
    public class RegionSettings
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        [Column("user_id")]
        public string UserId { get; set; }
        [ForeignKey("RegionId")]
        [Column("region_id")]
        public int RegionId { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("color_palette")]
        public int? ColorPalette { get; set; }
        public User? User { get; set; }
        public Region? Region { get; set; }
    }
}
