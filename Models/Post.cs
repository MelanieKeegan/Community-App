using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityAPI.Models
{
    public class Post
    {
        [Key]
        [Column("id")] // Map to the lowercase column name in Supabase
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("userid")]
        public long UserId { get; set; }  // set to long to match the Supabase schema
        [Column("title")]
        public String Title { get; set; }
        [Column("content")]
        public String Content { get; set; }
        [Column("category")] // Map to the lowercase column name in Supabase
        public String Category { get; set; }
        [Column("location")]
        public String Location { get; set; }
        [Column("contactinfo")] // Map to the lowercase column name in Supabase
        public String ContactInfo { get; set; }
        [Column("createdat")]
        public DateTime CreatedAt { get; set; } // Changed from DateTimeOffset to DateTime for SQL Server compatibility
    }
}
