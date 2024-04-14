﻿using AutoMapper;
using DiplomaProjects.Core.Models;
using DiplomaProjects.DataAccess.Entities;

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
