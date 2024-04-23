using DiplomaProjects.DataAccess.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.Applications
{
	public partial class StatusesConfiguraion : IEntityTypeConfiguration<StatusesEntity>
	{
		public void Configure(EntityTypeBuilder<StatusesEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.StatusesName).IsRequired();
		}
	}
}
