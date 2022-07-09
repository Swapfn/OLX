using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { set; get; }
        public List<Image> Images { set; get; }
        public Post()
        {
            Images = new List<Image>();
        }

    }
}
