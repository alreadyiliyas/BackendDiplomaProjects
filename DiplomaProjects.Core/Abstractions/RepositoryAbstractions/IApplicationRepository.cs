namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
    public interface IApplicationRepository
    {
        Task<List<Applications>> GetAllApplications();
        Task<List<Applications>> GetApplicationsByUserId(int userId, int roleId);
        Task<int> CreateApplication(Applications applications);
        Task<int> UpdateApplication(int ApplicationId, int StatusesId, int ClientId, int EmployeeId);
    }
}
