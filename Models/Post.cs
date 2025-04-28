namespace CommunityAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public String UserId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public String Category { get; set; }
        public String Location { get; set; }
        public String ContactInfo { get; set; }
        public String CreatedAt { get; set; }
    }
}
