using Microsoft.AspNetCore.Identity;

namespace Models.Models
{
    public interface Base
    {
        public class Base : BaseModel
        {
        }
    }
    public class ApplicationUser:IdentityUser<int>, Base
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public int Phone { set; get; }
        public string Email { set; get; }
        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        //[NotMapped]
        //public string ConfirmPassword { get; set; }
        //[ForeignKey("Role")]
        //public int RoleId { set; get; }
        //public application Role { get; set; }
        //public int LocationId { set; get; }
        //public Location Location { get; set; }
        public List<Post> Posts { get; set; }

        public ApplicationUser()
        {
            Posts = new List<Post>();
        }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
