using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TaskManagementAPI.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
