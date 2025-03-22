namespace TimeTrackingApi.Models
{
    public class WorkingDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TaskDescription { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
