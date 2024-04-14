using DiplomaProjects.Core.Models;
using System.Security.Claims;

namespace DiplomaProjects.Application.Auth
{
	public interface IJwtProvider
	{ 
		string GenerateToken(User user);
		string GenerateRefreshToken();
		ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
	}
}
