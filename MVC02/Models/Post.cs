using MVC02.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }
        public int Share { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
