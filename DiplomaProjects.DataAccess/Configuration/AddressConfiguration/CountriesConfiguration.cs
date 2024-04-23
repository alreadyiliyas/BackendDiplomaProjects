using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class CountriesConfiguration : IEntityTypeConfiguration<CountriesEntity>
	{
		public void Configure(EntityTypeBuilder<CountriesEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.CountriesName).IsRequired();
		}
	}
}
