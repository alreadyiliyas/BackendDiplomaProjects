using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Users
{
	public record RegisterUserRequest(
		[Required] string UserName,
		[Required] string Email,
		[Required] string Password,
		[Required] string UserRoleName
		);
}
