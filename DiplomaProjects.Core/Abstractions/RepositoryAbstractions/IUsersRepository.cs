using DiplomaProjects.Core.Models;

namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
	public interface IUsersRepository
	{
		Task<int> Add(Guid guidUserId, string email, string password, int userRoleId);
		Task<User> GetByEmail(string email);
		Task AddRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiryTime);
		Task<int> GetByGuid(Guid userGuid);
	}
}
