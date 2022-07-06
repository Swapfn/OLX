using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { set; get; }
        public string City { set; get; } //change??
        public List<User> Users { set; get; }
        public Location()
        {
            Users = new List<User>();
        }
    }
}
