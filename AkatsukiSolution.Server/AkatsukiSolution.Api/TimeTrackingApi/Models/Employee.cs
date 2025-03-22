namespace TimeTrackingApi.Models
{
    public class Employee : User
    {
        public Manager Manager { get; set; }
        
    }