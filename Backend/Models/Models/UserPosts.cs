
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class UserPosts
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public ApplicationUser Users { get; set; }
        [ForeignKey("Posts")]
        public int PostsId { get; set; }
        public Post Posts { get; set; }
    }
}
