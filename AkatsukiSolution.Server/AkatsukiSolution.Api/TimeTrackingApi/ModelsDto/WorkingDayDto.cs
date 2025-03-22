using AutoMapper;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.ModelsDto
{
    public class WorkingDayDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TaskDescription { get; set; }
        public decimal Hours { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}
