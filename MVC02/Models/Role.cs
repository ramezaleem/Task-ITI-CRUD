using MVC02.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC02.Models
{

    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
