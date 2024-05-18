using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchWorld.Models
{
    [Table("region", Schema = "public")]
    public class Region
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("ukr_name")]
        public string UkrName { get; set;}
        [Column("coordinates")]
        public string Coordinates { get; set; }
    }
}
