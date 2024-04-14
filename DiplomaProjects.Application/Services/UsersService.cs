using DiplomaProjects.Application.Auth;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions;
using DiplomaProjects.Core.DTOs;
using DiplomaProjects.Core.Models;

namespace DiplomaProjects.Application.Services
{
	public class UsersService : IUsersService
	{
		private readonly IPasswordHasher _passwordHasher;
		private readonly IUsersRepository _usersRepository;
		private readonly IJwtProvider _jwtProvider;
		private readonly IRolesRepository _rolessRepository;

		public UsersService(
			IUsersRepository usersRepository, 
			IRolesRepository rolesRepository, 
			IPasswordHasher passwordHasher, 
			IJwtProvider jwtProvider)
		{
			_usersRepository = usersRepository;
			_rolessRepository = rolesRepository;
			_passwordHasher = passwordHasher;
			_jwtProvider = jwtProvider;
		}
		public async Task Register(string userName, string email, string password, string userRoleName)
		{
			var userExists = await _usersRepository.GetByEmail(email);
			if (userExists != null)
			{
				throw new Exception("User already exists!");
			}
			var hashPassword = _passwordHasher.Generate(password);

			var userRoleId = await _rolessRepository.GetByRoleName(userRoleName.ToLower());
			var (user, error) = User.Create(1, Guid.NewGuid(), userName, email, hashPassword, userRoleId);

			if (!string.IsNullOrEmpty(error))
			{
				throw new Exception(error);
			}
			await _usersRepository.Add(user.GuidUserId, user.UserName, user.Email, user.PasswordHash, user.UserRoleId);
		}
		public async Task<AuthResultDTO> Login(string email, string password)
		{
			var user = await _usersRepository.GetByEmail(email);

			var result = _passwordHasher.Verify(password, user.PasswordHash);

			if (result == false)
			{
				throw new Exception("Failed to login");
			}

			var accessToken = _jwtProvider.GenerateToken(user);
			var refreshToken = _jwtProvider.GenerateRefreshToken();
			var expiration = DateTime.Now.AddDays(7);
			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiryTime = expiration;

			await _usersRepository.AddRefreshToken(user.Id, user.RefreshToken, user.RefreshTokenExpiryTime);

			return new AuthResultDTO
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken,
				Expiration = expiration
			};
		}
		public async Task<AuthResultDTO> GetRefreshToken(string accessToken, string refreshToken)
		{
			if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
			{
				throw new Exception("Invalid client request");
			}

			var principal = _jwtProvider.GetPrincipalFromExpiredToken(accessToken);

			if (principal == null)
			{
				throw new Exception("Invalid access token or refresh token");
			}

			string username = principal.Identity.Name;

			if (username == null) throw new Exception("Users dont find this gmail");

			var user = await _usersRepository.GetByEmail(username);
			if (user == null || user.RefreshToken != refreshToken)
			{
				throw new Exception("Invalid access token or refresh token");
			}
			var newAccessToken = _jwtProvider.GenerateToken(user);
			var newRefreshToken = _jwtProvider.GenerateRefreshToken();
			
			user.RefreshToken = newRefreshToken;
			user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(1);
			await _usersRepository.AddRefreshToken(user.Id, newRefreshToken, DateTime.Now.AddMinutes(1));

			// Возврат новых токенов
			return new AuthResultDTO
			{
				AccessToken = newAccessToken,
				RefreshToken = newRefreshToken
			};
		}
	}
}
