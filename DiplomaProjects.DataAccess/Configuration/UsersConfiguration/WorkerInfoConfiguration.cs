using DiplomaProjects.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.UsersConfiguration
{
	public partial class WorkerInfoConfiguration : IEntityTypeConfiguration<WorkerInfoEntity>
	{
		public void Configure(EntityTypeBuilder<WorkerInfoEntity> builder)
		{
			builder.HasKey(x => x.Id);
			
			builder.HasOne(u => u.User)
				.WithMany()
				.HasForeignKey(u => u.UserId)
				.IsRequired();
			
			builder.HasMany(wi => wi.Specialties)
				   .WithOne()
				   .HasForeignKey(ws => ws.WorkerId);
		}
	}
}