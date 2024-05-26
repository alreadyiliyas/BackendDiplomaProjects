using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions;


namespace DiplomaProjects.Application.Services.ApplicationsService
{
    public class ApplicationsServices : IApplicationsServices
	{
		private readonly IApplicationRepository _applicationRepoUniq;
		private readonly IMapper _mapper;
		public ApplicationsServices(
			IApplicationRepository applicationRepoUniq,
			IMapper mapper)
		{
			_applicationRepoUniq = applicationRepoUniq;
			_mapper = mapper;
		}
		public async Task<List<Applications>> GetAllApplications()
		{
			var applicationsEntities = await _applicationRepoUniq.GetAllApplications();
			return _mapper.Map<List<Applications>>(applicationsEntities);
		}
		public async Task<List<Applications>> GetPersonalApplication(int userId, int roleId)
		{
			var applicationsEntities = await _applicationRepoUniq.GetApplicationsByUserId(userId, roleId);
			return _mapper.Map<List<Applications>>(applicationsEntities);
		}
		public async Task<int> CreateApplication(Applications applications)
		{
			var applicationEntity = await _applicationRepoUniq.CreateApplication(applications);

			return applicationEntity;
		}
		public async Task<int> TakeJob(int ApplicationId, int StatusesId, int ClientId, int EmployeeId)
		{
			var applicationEntity = await _applicationRepoUniq.UpdateApplication(ApplicationId, StatusesId, ClientId, EmployeeId);

			return applicationEntity;
		}
	}
}
