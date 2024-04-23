using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class CitiesConfiguration : IEntityTypeConfiguration<CitiesEntity>
	{
		public void Configure(EntityTypeBuilder<CitiesEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.CitiesName).IsRequired();

			builder.HasOne(x => x.Regions).WithMany().HasForeignKey(x => x.RegionsId);
		}
	}
}
