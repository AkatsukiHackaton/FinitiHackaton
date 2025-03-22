namespace TimeTrackingApi.Models
{
    public class WorkingDay : BaseModel
    {
        public DateTime Date { get; set; }
        public string TaskDescription { get; set; }
        public decimal Hours { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
