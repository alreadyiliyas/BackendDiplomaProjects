namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
    public interface IApplicationRepository
    {
        Task<List<Applications>> GetAllApplications();
        Task<List<Applications>> GetApplicationsByUserId(int userId, int roleId);
        Task<List<Applications>> GetAllApplicationByCity(int CityId, int RoleId);
		Task<int> CreateApplication(Applications applications);
        Task<int> UpdateApplicationModerator(int ApplicationId, int StatusesId, int ClientId, int HandlerPersonId);
        Task<int> UpdateApplicationEmployee(int ApplicationId, int StatusesId, int ClientId, int HandlerPersonId);
        Task<int> GetCitiesIdByUserId(int userId);

	}
}
