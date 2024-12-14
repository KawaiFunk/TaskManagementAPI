namespace TaskManagementAPI.Models
{
    public class Task
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }

        // Foreign key for User
        public Guid UserId { get; set; }
        public User User { get; set; }

        //Foreign key for Category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
