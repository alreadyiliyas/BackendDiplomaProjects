namespace DiplomaProjects.Core.Abstractions.ApplicationsAbstractions
{
	public interface IApplicationRepository
	{
		Task<List<Applications>> GetAllApplications();
		Task<int> CreateApplication(Applications applications);
	}
}
