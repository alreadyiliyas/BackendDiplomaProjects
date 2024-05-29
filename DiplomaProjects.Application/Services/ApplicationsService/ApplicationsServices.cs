using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions;
using DiplomaProjects.DataAccess.Repositories;


namespace DiplomaProjects.Application.Services.ApplicationsService
{
    public class ApplicationsServices : IApplicationsServices
	{
		private readonly IApplicationRepository _applicationRepoUniq;
		private readonly IUsersRepository _usersRepository;
		private readonly IRolesRepository _rolesRepository;
		private readonly IStatusesServices _statusesServices;
		private readonly IMapper _mapper;
		public ApplicationsServices(
			IApplicationRepository applicationRepoUniq,
			IUsersRepository usersRepository,
			IRolesRepository rolesRepository,
			IStatusesServices statusesServices,
			IMapper mapper)
		{
			_applicationRepoUniq = applicationRepoUniq;
			_usersRepository = usersRepository;
			_rolesRepository = rolesRepository;
			_statusesServices = statusesServices;
			_mapper = mapper;
		}
		public async Task<List<Applications>> GetAllApplications()
		{
			var applicationsEntities = await _applicationRepoUniq.GetAllApplications();
			return _mapper.Map<List<Applications>>(applicationsEntities);
		}
		public async Task<List<Applications>> GetAllApplicationByCity(int CityId, string UserRoleName)
		{
			int roleId = await _rolesRepository.GetByRoleName(UserRoleName);
			var applicationsEntities = await _applicationRepoUniq.GetAllApplicationByCity(CityId, roleId);

			return _mapper.Map<List<Applications>>(applicationsEntities);
		}
		public async Task<List<Applications>> GetPersonalApplication(int userId, int roleId)
		{
			var applicationsEntities = await _applicationRepoUniq.GetApplicationsByUserId(userId, roleId);
			return _mapper.Map<List<Applications>>(applicationsEntities);
		}
		public async Task<int> CreateApplication(string Title, string Description, List<string> FilesPath, Guid UserGuid)
		{
			int userId = await _usersRepository.GetByGuid(UserGuid);
			
			var defaultStatusesId = 1;
			
			var defaultStatus = await _statusesServices.GetdDefaultStatusesAsync(defaultStatusesId);
			
			int citiesId = await _applicationRepoUniq.GetCitiesIdByUserId(userId);

			var (applications, error) = Applications.Create(
				id: 0,
				title: Title,
				description: Description,
				statuses: defaultStatus,
				clientId: userId,
				citiesId: citiesId,
				moderatorId: null,
				employeeId: null,
				createdAt: DateTime.Now,
				lastModifiedAt: DateTime.Now,
				imagePaths: FilesPath
				);

			if (!string.IsNullOrEmpty(error))
			{
				throw new Exception(error);
			}

			var res = await _applicationRepoUniq.CreateApplication(applications);

			return res;
		}
		public async Task<int> UpdateState(int ApplicationId, int StatusesId, int ClientId, int HandlerPersonId, string HandlerPersonRoleName)
		{
			int applicationEntity; // Declare the variable at a higher scope

			if (HandlerPersonRoleName == "moderator")
			{
				applicationEntity = await _applicationRepoUniq.UpdateApplicationModerator(ApplicationId, StatusesId, ClientId, HandlerPersonId);
			}
			else if (HandlerPersonRoleName == "worker")
			{
				applicationEntity = await _applicationRepoUniq.UpdateApplicationEmployee(ApplicationId, StatusesId, ClientId, HandlerPersonId);
			}
			else
			{
				throw new ArgumentException("Ошибочное название роли"); // It's good to handle unexpected role names
			}

			return applicationEntity;
		}
	}
}
