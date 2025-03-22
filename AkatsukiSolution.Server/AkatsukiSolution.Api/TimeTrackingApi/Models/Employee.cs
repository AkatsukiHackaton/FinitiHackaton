namespace TimeTrackingApi.Models
{
    public class Employee : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public EmployeeTypeEnum Type { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}