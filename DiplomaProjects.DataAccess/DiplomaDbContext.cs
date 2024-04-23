using DiplomaProjects.DataAccess.Entities.Address;
using DiplomaProjects.DataAccess.Entities.Users;
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
		public DbSet<CountriesEntity> Countries { get; set; }
		public DbSet<RegionsEntity> Regions { get; set; }
		public DbSet<CitiesEntity> Cities { get; set; }
		public DbSet<DistrictsEntity> Districts { get; set; }
		public DbSet<MicroDistrictsEntity> MicroDistricts { get; set; }
		public DbSet<StreetsEntity> Streets { get; set; }
		public DbSet<AddressOfHouseEntity> AddressOfHouses { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
