using DiplomaProjects.Core.Models.ApplicationsModels;
namespace DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions
{
	public interface IApplicationsServices
	{
		Task<int> CreateApplication(Applications applications);
		Task<List<Applications>> GetAllApplications();
		Task<List<Applications>> GetPersonalApplication(int userGuid, int userRoleId);
		Task<int> TakeJob(int ApplicationId, int StatusesId, int ClientId, int EmployeeId);
	}
}
