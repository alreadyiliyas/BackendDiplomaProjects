using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class DistrictsConfiguration : IEntityTypeConfiguration<DistrictsEntity>
	{
		public void Configure(EntityTypeBuilder<DistrictsEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.DistrictsName).IsRequired();

			builder.HasOne(x=>x.Cities).WithMany().HasForeignKey(x => x.CityId).IsRequired();
		}
	}
}
