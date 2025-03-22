namespace TimeTrackingApi.Models
{
    public class Manager : BaseModel
    {
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Project> Projects { get; set; } = new();
        public List<Employee> Employees { get; set; }
    }
}
