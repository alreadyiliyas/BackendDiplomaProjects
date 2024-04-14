using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Users
{
	public record RefreshToken(
		[Required] string AccessTokenReq,
		[Required] string RefreshTokenReq
		);
}
