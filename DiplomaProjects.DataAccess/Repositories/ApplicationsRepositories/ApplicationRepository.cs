using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions;
using DiplomaProjects.Core.Models;
using DiplomaProjects.DataAccess.Entities.Application;
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

		public async Task<int> CreateApplication(Applications applications)
		{
			try
			{
				var applicationEntity = new ApplicationsEntity
				{
					Title = applications.Title,
					Description = applications.Description,
					StatusesId = applications.Statuses.Id,
					ClientId = applications.ClientId,
					ModeratorId = applications.ModeratorId, // Может быть null
					EmployeeId = applications.EmployeeId, // Может быть null
					CreatedAt = applications.CreatedAt,
					LastModifiedAt = applications.LastModifiedAt,
					ImagePaths = applications.ImagePaths
				};

				await _context.Applications.AddAsync(applicationEntity);
				await _context.SaveChangesAsync();

				return applicationEntity.Id;
			}
			catch (Exception)
			{
				return -1;
			}
			
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
