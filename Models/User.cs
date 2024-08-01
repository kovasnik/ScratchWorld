using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScratchWorld.Models
{
    [Table("user", Schema = "public")]
    public class User : IdentityUser
    {

        [Column("name")]
        public string? Name { get; set; }

        [Column("age")]
        public int Age { get; set; }
    }
}
