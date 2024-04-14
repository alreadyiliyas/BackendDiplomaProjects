using AutoMapper;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProjects.DataAccess.Repositories
{
	public class RolesRepository : IRolesRepository
	{
		private readonly DiplomaDbContext _context;

		public RolesRepository(DiplomaDbContext context)
		{
			_context = context;
		}
		public async Task<int> GetByRoleName(string roleName)
		{
			var roleEntity = await _context.Roles
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Name == roleName);

			return roleEntity.Id;
		}
	}
}
