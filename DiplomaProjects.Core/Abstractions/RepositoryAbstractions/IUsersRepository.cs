using DiplomaProjects.Core.Models;

namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
	public interface IUsersRepository
	{
		Task Add(Guid guidUserId, string email, string password, int userRoleId);
		Task<User> GetByEmail(string email);
		Task AddRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiryTime);
	}
}
