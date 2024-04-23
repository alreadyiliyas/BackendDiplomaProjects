using DiplomaProjects.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.UsersConfiguration
{
	public partial class WorkerSpecialtyConfiguration : IEntityTypeConfiguration<WorkerSpecialtyEntity>
	{
		public void Configure(EntityTypeBuilder<WorkerSpecialtyEntity> builder)
		{
			builder.HasKey(ws => new { ws.WorkerId, ws.SpecialtyId });

			builder.HasOne(ws => ws.Worker)
				   .WithMany(w => w.Specialties)
				   .HasForeignKey(ws => ws.WorkerId);

			builder.HasOne(ws => ws.Specialty)
				   .WithMany()
				   .HasForeignKey(ws => ws.SpecialtyId);
		}
	}
}
