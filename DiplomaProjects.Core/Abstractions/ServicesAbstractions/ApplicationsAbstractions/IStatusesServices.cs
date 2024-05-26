using DiplomaProjects.Core.Models.ApplicationsModels;

namespace DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions
{
	public interface IStatusesServices
	{
		Task<Statuses> GetdDefaultStatusesAsync(int id);
		Task<List<Statuses>> GetAllStatusesAsync();
	}
}
