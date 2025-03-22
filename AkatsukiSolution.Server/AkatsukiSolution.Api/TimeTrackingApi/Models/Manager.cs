namespace TimeTrackingApi.Models
{
    public class Manager : User
    {
        public List<Project> Projects { get; set; } = new();
    }
}
