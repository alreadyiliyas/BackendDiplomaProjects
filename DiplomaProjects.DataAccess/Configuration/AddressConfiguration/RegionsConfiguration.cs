using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class RegionsConfiguration : IEntityTypeConfiguration<RegionsEntity>
	{
		public void Configure(EntityTypeBuilder<RegionsEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.RegionsName).IsRequired();

			builder.HasOne(x => x.Countries)
				.WithMany()
				.HasForeignKey(x => x.CountryId)
				.IsRequired();
		}
	}
}
