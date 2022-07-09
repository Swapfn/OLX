using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageID { get; set; }
        public byte[] ImageContent { get; set; }
        [ForeignKey("Post")]
        public int PostId { set; get; }
        public Post Post { get; set; }
        
    }
}
