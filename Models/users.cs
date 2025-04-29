using CommunityAPI.Enums;
namespace CommunityAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace CommunityAPI.Models
    {
        [Table("users")]
        public class User
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public long Id { get; set; }

            [Required]
            [Column("name")]
            public string Name { get; set; }

            [Required]
            [Column("email")]
            public string Email { get; set; }

            // this column is nullable in your schema; drop [Required] if you want to allow nulls
            [Column("role")]
            public Role Role { get; set; }

            [Column("created_at")]
            public DateTimeOffset CreatedAt { get; set; }
        }
    }

}
