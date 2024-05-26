using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Models;
using DiplomaProjects.Core.Models.ApplicationsModels;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
				.Where(a => a.StatusesId == 1)
				.ToListAsync();

			var application = _mapper.Map<List<Applications>>(applicationEntity);
			return application;
		}
		public async Task<List<Applications>> GetApplicationsByUserId(int userId, int roleId)
		{
			try
			{
				var query = _context.Applications
									.Include(a => a.Statuses)    // Включаем связанные данные для Statuses
									.Include(a => a.Client)      // Включаем связанные данные для Client
									.Include(a => a.Moderator)   // Включаем связанные данные для Moderator
									.Include(a => a.Employee)    // Включаем связанные данные для Employee
									.AsNoTracking();

				// Фильтрация по ролям
				if (roleId == 1) // Client
				{
					query = query.Where(a => a.ClientId == userId);
				}
				else if (roleId == 3) // Worker
				{
					query = query.Where(a => a.EmployeeId == userId);
				}

				var applicationEntities = await query.ToListAsync();

				var applications = _mapper.Map<List<Applications>>(applicationEntities);
				return applications;
			}
			catch (Exception)
			{
				throw new Exception("Ошибка при получении персональных заявок");
			}
		}


		public async Task<int> UpdateApplication(int ApplicationId, int StatusesId, int ClientId, int EmployeeId)
		{
			try
			{
				var applicationEntity = await _context.Applications
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.Id == ApplicationId);

				if (applicationEntity == null)
				{
					return -1;
				}

				applicationEntity.StatusesId = StatusesId;
				applicationEntity.EmployeeId = EmployeeId;
				applicationEntity.LastModifiedAt = DateTime.UtcNow;

				_context.Applications.Update(applicationEntity);
				await _context.SaveChangesAsync();
				return applicationEntity.Id;
			}
			catch (Exception)
			{
				throw new Exception("An error occurred while updating the application.");
			}
		}
	}
}
