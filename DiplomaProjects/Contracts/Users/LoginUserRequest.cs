using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Users
{
	public record LoginUserRequest(
		[Required] string Email,
		[Required] string Password
		);
}
