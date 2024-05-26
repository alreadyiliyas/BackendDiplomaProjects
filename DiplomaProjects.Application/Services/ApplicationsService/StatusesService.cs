using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions;
using DiplomaProjects.Core.Models.ApplicationsModels;
using DiplomaProjects.DataAccess.Entities.Application;

namespace DiplomaProjects.Application.Services.ApplicationsService
{
	public class StatusesService : IStatusesServices
	{
		private readonly IRepositories<StatusesEntity> _statusesRepository;
		private readonly IMapper _mapper;

		public StatusesService(IRepositories<StatusesEntity> statusesRepository, IMapper mapper)
		{
			_statusesRepository = statusesRepository;
			_mapper = mapper;
		}

		public async Task<List<Statuses>> GetAllStatusesAsync()
		{
			var statusesEntities = _statusesRepository.GetAll();
			return _mapper.Map<List<Statuses>>(statusesEntities);
		}

		public async Task<Statuses> GetdDefaultStatusesAsync(int id)
		{
			var statusesEntity = _statusesRepository.GetById(id);
			return _mapper.Map<Statuses>(statusesEntity);
		}

	}
}
