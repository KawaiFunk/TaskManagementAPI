using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models.DTOs
{
    public class UserReturnDTO
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public ICollection<TaskReturnDTO> Tasks { get; set; }
    }
}
