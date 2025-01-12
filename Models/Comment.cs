using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchWorld.Models
{
    [Table("comment", Schema = "public")]
    public class Comment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("comment_text")]
        public string CommentText { get; set; }
        [Column("comment_date")]
        public DateTime CommentDate { get; set; }
        [ForeignKey("UserId")]
        [Column("user_id")]
        public string UserId  { get; set; }
        [ForeignKey("RegionId")]
        [Column("region_id")]
        public int? RegionId { get; set; }
        [ForeignKey("LandmarkId")]
        [Column("landmark_id")]
        public int? LandmarkId { get; set; }
        [Column("parent_comment")]
        public int ParentComment { get; set; }
        public User? User { get; set; }
        public Region? Region { get; set; }
        public Landmark? Landmark { get; set; }
    }
}
