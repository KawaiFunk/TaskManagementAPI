using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
