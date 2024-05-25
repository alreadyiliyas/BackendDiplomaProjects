using AutoMapper;
using DiplomaProjects.Core.Abstractions.ApplicationsAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProjects.DataAccess.Repositories.ApplicationRepositories
{
	public class ApplicationRepository : IApplicationRepository
	{
		private readonly DiplomaDbContext _context;
		private readonly IMapper _mapper;

		public ApplicationRepository(DiplomaDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<Applications>> GetAllApplications()
		{
			var applicationEntity = await _context.Applications
				.Include("Statuses")     // Включаем связанные данные для Statuses
				.Include("Client")       // Включаем связанные данные для Client
				.Include("Moderator")    // Включаем связанные данные для Moderator
				.Include("Employee")
				.AsNoTracking()
				.ToListAsync();

			var application = _mapper.Map<List<Applications>>(applicationEntity);
			return application;
		}
	}
}
