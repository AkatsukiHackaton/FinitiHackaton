using TimeTrackingApi.ModelsDto;

namespace TimeTrackingApi.Models
{
    public class WorkingDay : BaseModel
    {
        public DateTime Date { get; set; }
        public string TaskDescription { get; set; }
        public decimal Hours { get; set; }
        public User Employee { get; set; }
        public Project Project { get; set; }
    }
}
