﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchWorld.Models
{
    [Table("landmark", Schema = "public")]
    public class Landmark
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("coordinates")]
        public  string Coordinates { get; set; }
        [ForeignKey("RegionId")]
        [Column("region_id")]
        public int RegionId { get; set; }
        public Region? Region { get; set; }
    }
}
