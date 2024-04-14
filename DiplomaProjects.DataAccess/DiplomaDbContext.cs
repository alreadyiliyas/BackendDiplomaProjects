using DiplomaProjects.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProjects.DataAccess
{
	public class DiplomaDbContext : DbContext
	{
		public DiplomaDbContext(DbContextOptions<DiplomaDbContext> options) 
			: base(options) 
		{
		
		}
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<RoleEntity> Roles { get; set; }	
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
