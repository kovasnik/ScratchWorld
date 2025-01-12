using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScratchWorld.Models
{
    [Table("likes", Schema = "public")]
    public class Likes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public string UserId { get; set; }
        [ForeignKey(nameof(Region))]
        [Column("region_id")]
        public int? RegionId { get; set; }
        [ForeignKey(nameof(Landmark))]
        [Column("landmark_id")]
        public int? LandmarkId { get; set; }
        public Landmark? Landmark { get; set; }
        public User? User { get; set; }
        public Region? Region { get; set; }

    }
}
