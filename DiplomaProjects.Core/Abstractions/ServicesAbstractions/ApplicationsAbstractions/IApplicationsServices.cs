using DiplomaProjects.Core.Models.ApplicationsModels;
using System.ComponentModel.DataAnnotations;

namespace DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions
{
	public interface IApplicationsServices
	{
		Task<int> CreateApplication(string Title, string Description, List<string> FilesPath, Guid UserGuid);
		Task<List<Applications>> GetAllApplications();
		Task<List<Applications>> GetAllApplicationByCity(int CityId, string UserRoleName);
		Task<List<Applications>> GetPersonalApplication(int userGuid, int userRoleId);
		Task<int> UpdateState(int ApplicationId, int StatusesId, int ClientId, int HandlerPersonId, string HandlerPersonRoleName);
	}
}
