using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Applications.Request
{
	public record UpdateStateApplicationbRequest(
		[Required] int ApplicationId,
		[Required] int StatusesId,
		[Required] int ClientId,
		[Required] Guid HandlerPersonGuid,
		[Required] string HandlerPersonRoleName
		);
}
