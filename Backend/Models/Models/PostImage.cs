using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class PostImage
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostImageID { get; set; }
        //public byte[] ImageContent { get; set; }
        public string ImageURL { get; set; }
        //[ForeignKey("Post")]
        public int PostId { set; get; }
        public Post Post { get; set; }

    }
}
