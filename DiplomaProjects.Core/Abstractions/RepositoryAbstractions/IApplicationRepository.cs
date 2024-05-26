namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
    public interface IApplicationRepository
    {
        Task<List<Applications>> GetAllApplications();
        Task<int> CreateApplication(Applications applications);
    }
}
