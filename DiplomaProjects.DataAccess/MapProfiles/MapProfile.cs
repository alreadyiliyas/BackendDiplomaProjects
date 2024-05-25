using AutoMapper;
using DiplomaProjects.Core.Models;
using DiplomaProjects.Core.Models.AddressModels;
using DiplomaProjects.Core.Models.ApplicationsModels;
using DiplomaProjects.Core.Models.UsersModels;
using DiplomaProjects.DataAccess.Entities.Address;
using DiplomaProjects.DataAccess.Entities.Application;
using DiplomaProjects.DataAccess.Entities.Users;

namespace DiplomaProjects.DataAccess.MapProfiles
{
    public class MapProfile : Profile
	{
		public MapProfile() 
		{
			CreateMap<UserEntity, User>().ReverseMap();
			CreateMap<RoleEntity, Role>().ReverseMap();
			CreateMap<CountriesEntity, Countries>().ReverseMap();
			CreateMap<RegionsEntity, Regions>().ReverseMap();
			CreateMap<CitiesEntity, Cities>().ReverseMap();
			CreateMap<DistrictsEntity, Districts>().ReverseMap();
			CreateMap<MicroDistrictsEntity, MicroDistricts>().ReverseMap();
			CreateMap<StreetsEntity, Streets>().ReverseMap();
			CreateMap<StreetDistrictsEntity, StreetsDistricts>().ReverseMap();
			CreateMap<AddressOfHouseEntity, AddressOfHouses>().ReverseMap();
			CreateMap<UserInfoEntity, UserInfo>().ReverseMap();
			CreateMap<ApplicationsEntity, Applications>().ReverseMap();
			CreateMap<StatusesEntity, Statuses>().ReverseMap();
		}
	}
}
