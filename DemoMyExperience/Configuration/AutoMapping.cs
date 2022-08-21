using AutoMapper;
using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience.Models;
using DemoMyExperience.Models;
using static System.Net.Mime.MediaTypeNames;

namespace DemoMyExperience.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserRepository, User>().ForMember(u => u.Name, opt => opt.MapFrom(uR => uR.FirstName));
            CreateMap<User, UserRepository>().ForMember(uR => uR.FirstName, opt => opt.MapFrom(u => u.Name));
        }
    }
}
