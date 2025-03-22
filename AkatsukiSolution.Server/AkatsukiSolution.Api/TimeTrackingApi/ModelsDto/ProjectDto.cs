using AutoMapper;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.ModelsDto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Manager { get; set; }

        internal class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Project, ProjectDto>();
            }
        }
    }
}
