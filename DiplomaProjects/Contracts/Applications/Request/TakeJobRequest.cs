using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Applications.Request
{
	public record TakeJobRequest(
		[Required] int ApplicationId,
		[Required] int StatusesId,
		[Required] int ClientId,
		[Required] Guid EmployeeGuid
		);
}
