using DiplomaProjects.DataAccess.Entities.Address;
using DiplomaProjects.DataAccess.Entities.Application;
using DiplomaProjects.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DiplomaProjects.DataAccess
{
    public class DiplomaDbContext : DbContext
	{
		public DiplomaDbContext(DbContextOptions<DiplomaDbContext> options)
			: base(options) 
		{
		
		}
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<UserInfoEntity> UserInfo { get; set; }
		public DbSet<RoleEntity> Roles { get; set; }
		public DbSet<SpecialtiesEntity> Specialties { get; set; }
		public DbSet<WorkerInfoEntity> WorkerInfo { get; set; }
		public DbSet<WorkerSpecialtyEntity> WorkerSpecialtyEntities { get; set; }

		public DbSet<CountriesEntity> Countries { get; set; }
		public DbSet<RegionsEntity> Regions { get; set; }
		public DbSet<CitiesEntity> Cities { get; set; }
		public DbSet<DistrictsEntity> Districts { get; set; }
		public DbSet<MicroDistrictsEntity> MicroDistricts { get; set; }
		public DbSet<StreetsEntity> Streets { get; set; }
		public DbSet<StreetDistrictsEntity> StreetDistricts { get; set; }
		public DbSet<AddressOfHouseEntity> AddressOfHouses { get; set; }
		public DbSet<ApplicationsEntity> Applications { get; set; }
		public DbSet<StatusesEntity> Statuses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<WorkerSpecialtyEntity>()
				.HasKey(ws => new { ws.WorkerId, ws.SpecialtyId });

			builder.Entity<StreetDistrictsEntity>()
				.HasKey(ws => new { ws.StreetsId, ws.DistrictsId });
		}
	}
}
