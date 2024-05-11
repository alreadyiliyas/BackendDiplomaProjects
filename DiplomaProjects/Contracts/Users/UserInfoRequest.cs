using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Users
{
	public record UserInfoRequest(
		[Required] int UserId,
		[Required] string Surname,
		[Required] string Name,
		[Required] string BirthDate,
		[Required] string PhoneNumber,
		[Required] string IdentityNumberKZT
		);
}
