using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions;
using DiplomaProjects.Core.Models.AddressModels;
using DiplomaProjects.Core.Models.ApplicationsModels;
using DiplomaProjects.DataAccess.Entities.Application;


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
			var countryEntities = await _applicationRepoUniq.GetAllApplications();
			return _mapper.Map<List<Applications>>(countryEntities);
		}
		public async Task<int> CreateApplication(Applications applications)
		{
			var applicationEntity = await _applicationRepoUniq.CreateApplication(applications);

			return applicationEntity;
		}
	}
}
