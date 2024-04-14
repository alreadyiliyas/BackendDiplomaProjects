using DiplomaProjects.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProjects.DataAccess.Configuration
{
	public partial class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
	{
		public void Configure(EntityTypeBuilder<RoleEntity> builder)
		{
			builder.HasKey(x => x.Id);
		}
	}
}
