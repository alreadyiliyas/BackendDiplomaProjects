using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions;
using DiplomaProjects.Core.Models.UsersModels;
using DiplomaProjects.DataAccess.Entities.Users;

namespace DiplomaProjects.Application.Services.UsersService
{
	public class UserInfoService : IUsersInfoServices
	{
		private readonly IRepositories<UserInfoEntity> _usersInfoRepository;
		private readonly IMapper _mapper;

		public UserInfoService(
			IRepositories<UserInfoEntity> usersInfoRepository, 
			IMapper mapper)
		{
			_usersInfoRepository = usersInfoRepository;
			_mapper = mapper;
		}
		public async Task<List<UserInfo>> GetAllUsersInfo()
		{
			var userInfoEntity = _usersInfoRepository.GetAll();
			return _mapper.Map<List<UserInfo>>(userInfoEntity);

		}
		public async Task<UserInfo> GetUsersInfoByGuid(int userId)
		{
			var userInfoEntity = _usersInfoRepository.GetById(userId);
			return _mapper.Map<UserInfo>(userInfoEntity);
		}
		public async Task<int> AddUserInfo(UserInfo userInfo)
		{
			var userInfoEntity = _mapper.Map<UserInfoEntity>(userInfo);
			if (_usersInfoRepository.Add(userInfoEntity))
				return userInfoEntity.Id;
			else
				return -1;
		}
	}
}
