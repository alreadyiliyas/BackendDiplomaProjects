using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class MicroDistrictsConfiguration : IEntityTypeConfiguration<MicroDistrictsEntity>
	{
		public void Configure(EntityTypeBuilder<MicroDistrictsEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.MicroDistrictsName).IsRequired();

			builder.HasOne(x=>x.Districts).WithMany().HasForeignKey(x =>x.DistrictId).IsRequired();
		}
	}
}
