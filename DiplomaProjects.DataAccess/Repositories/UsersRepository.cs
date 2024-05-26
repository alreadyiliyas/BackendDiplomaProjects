using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Models;
using DiplomaProjects.DataAccess.Entities;
using DiplomaProjects.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProjects.DataAccess.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly DiplomaDbContext _context;
		private readonly IMapper _mapper;

		public UsersRepository(DiplomaDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<int> Add(Guid guidUserId, string email, string password, int userRoleId)
		{
			var userEntity = new UserEntity
			{
				GuidUserId = guidUserId,
				Email = email,
				PasswordHash = password,
				UserRoleId = userRoleId,
			};
			await _context.Users.AddAsync(userEntity);
			await _context.SaveChangesAsync();

			return userEntity.Id;
		}
		public async Task<User> GetByEmail(string email)
		{
			var userEntity = await _context.Users
								.Include(u => u.UserRole)
								.AsNoTracking()
								.FirstOrDefaultAsync(x => x.Email == email);

			// Если пользователь найден, асинхронно получаем роль
			if (userEntity != null)
			{
				// Получаем связанную роль
				var userRole = await _context.Roles.FirstOrDefaultAsync(ur => ur.Id == userEntity.UserRoleId);
				if (userRole != null)
				{
					var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == userRole.Id);
					userEntity.UserRole = userRole;
					userEntity.UserRole.Name = role.Name;
				}
			}

			var user = _mapper.Map<User>(userEntity);

			return user;
		}

		public async Task AddRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiryTime)
		{
			var user = await _context.Users.FindAsync(id);
			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiryTime = refreshTokenExpiryTime.ToUniversalTime();

			await _context.SaveChangesAsync();
		}

		public async Task<int> GetByGuid(Guid userGuid)
		{
			var userEntity = await _context.Users
									.AsNoTracking()
									.FirstOrDefaultAsync(x => x.GuidUserId == userGuid);
			var user = _mapper.Map<User>(userEntity);
			return user.Id;
		}
	}
}
