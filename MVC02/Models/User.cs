using MVC02.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public List<Post>? Posts { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}