namespace TimeTrackingApi.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public User Manager { get; set; }
    }
}
