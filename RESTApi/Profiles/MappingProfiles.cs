using AutoMapper;
using RESTApi.Dtos;
using RESTApi.Models.Database;

namespace RESTApi.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PolicieDto, Policie>();
        }
    }
}
