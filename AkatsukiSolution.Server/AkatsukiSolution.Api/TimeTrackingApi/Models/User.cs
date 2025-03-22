using Microsoft.AspNetCore.Identity;

namespace TimeTrackingApi.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public User? Manager { get; set; }
    }
}
