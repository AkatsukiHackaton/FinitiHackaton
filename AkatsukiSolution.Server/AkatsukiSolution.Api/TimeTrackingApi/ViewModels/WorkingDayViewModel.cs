namespace TimeTrackingApi.ModelsDto
{
    public class WorkingDayViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TaskDescription { get; set; }
        public decimal Hours { get; set; }
        public string EmployeeFullName { get; set; }
        public string ProjectName { get; set; }
    }
}
