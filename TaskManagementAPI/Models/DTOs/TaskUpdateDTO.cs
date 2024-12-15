namespace TaskManagementAPI.Models.DTOs
{
    public class TaskUpdateDTO
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
    }
}
