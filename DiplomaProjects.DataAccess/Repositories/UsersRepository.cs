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

		public async Task Add(Guid guidUserId, string email, string password, int userRoleId)
		{
			var userEntity = new UserEntity
			{
				GuidUserId = Guid.NewGuid(),
				Email = email,
				PasswordHash = password,
				UserRoleId = userRoleId,
			};
			await _context.Users.AddAsync(userEntity);
			await _context.SaveChangesAsync();
		}
		public async Task<User> GetByEmail(string email)
		{
			var userEntity = await _context.Users
						.AsNoTracking()
						.FirstOrDefaultAsync(x => x.Email == email);

			return _mapper.Map<User>(userEntity);
		}
		public async Task AddRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiryTime)
		{
			var user = await _context.Users.FindAsync(id);
			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiryTime = refreshTokenExpiryTime.ToUniversalTime();

			await _context.SaveChangesAsync();
		}
	}
}
