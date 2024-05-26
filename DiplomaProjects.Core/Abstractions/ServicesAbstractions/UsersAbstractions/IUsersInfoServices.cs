using DiplomaProjects.Core.Models.UsersModels;

namespace DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions
{
	public interface IUsersInfoServices
	{
		Task<List<UserInfo>> GetAllUsersInfo();
		Task<int> AddUserInfo(UserInfo userInfo);
		Task<UserInfo> GetUsersInfoByGuid(int userId);
	}
}
