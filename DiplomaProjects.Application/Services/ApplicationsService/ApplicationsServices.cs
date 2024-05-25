using AutoMapper;
using DiplomaProjects.Core.Abstractions.ApplicationsAbstractions;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions;
using DiplomaProjects.Core.Models.AddressModels;
using DiplomaProjects.Core.Models.ApplicationsModels;
using DiplomaProjects.DataAccess.Entities.Application;


namespace DiplomaProjects.Application.Services.ApplicationsService
{
	public class ApplicationsServices : IApplicationsServices
	{
		private readonly IRepositories<ApplicationsEntity> _applicationRepository;
		private readonly IApplicationRepository<ApplicationsEntity> _applicationRepoUniq;
		private readonly IMapper _mapper;
		public ApplicationsServices(
			IRepositories<ApplicationsEntity> applicationRepository,
			IApplicationRepository<ApplicationsEntity> applicationRepoUniq,
			IMapper mapper)
		{
			_applicationRepository = applicationRepository;
			_applicationRepoUniq = applicationRepoUniq;
			_mapper = mapper;
		}
		public async Task<List<Applications>> GetAllApplications()
		{
			var countryEntities = _applicationRepoUniq.GetAll();
			return _mapper.Map<List<Applications>>(countryEntities);
		}
		public async Task<int> CreateApplication(Applications applications)
		{
			var applicationEntity = _mapper.Map<ApplicationsEntity>(applications);
			if (_applicationRepository.Add(applicationEntity))
				return applicationEntity.Id;
			else
				return -1;
		}
	}
}
