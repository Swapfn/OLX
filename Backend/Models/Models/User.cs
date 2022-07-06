using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public int Phone { set; get; }
        public string Email { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [ForeignKey("Role")]
        public int RoleId { set; get; }
        public Role Role { get; set; }
        [ForeignKey("Location")]
        public int LocationId { set; get; }
        public Location Location { get; set; }
    }
}
