using DiplomaProjects.Core.DTOs;

namespace DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions
{
    public interface IUsersService
    {
        Task Register(string userName, string email, string password, string userRoleName);
        Task<AuthResultDTO> Login(string email, string password);
        Task<AuthResultDTO> GetRefreshToken(string accessToken, string refreshToken);
    }
}
