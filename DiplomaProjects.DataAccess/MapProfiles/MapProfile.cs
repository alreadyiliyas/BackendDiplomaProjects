using AutoMapper;
using DiplomaProjects.Core.Models;
using DiplomaProjects.DataAccess.Entities.Users;

namespace DiplomaProjects.DataAccess.MapProfiles
{
    public class MapProfile : Profile
	{
		public MapProfile() 
		{
			CreateMap<UserEntity, User>().ReverseMap();
			CreateMap<RoleEntity, Role>().ReverseMap();
		}
	}
}
