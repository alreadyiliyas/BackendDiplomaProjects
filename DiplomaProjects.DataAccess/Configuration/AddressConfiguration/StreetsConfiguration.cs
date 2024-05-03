using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class StreetsConfiguration : IEntityTypeConfiguration<StreetsEntity>
	{
		public void Configure(EntityTypeBuilder<StreetsEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.StreetsName).IsRequired();
		}
	}
}
