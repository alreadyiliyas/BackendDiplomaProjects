using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Contracts.Applications.Request
{
	public record ApplicationsRequest(
		[Required] string Title,
		[Required] string Description,
		List<IFormFile> Files,
		[Required] Guid UserGuid
		);
}
