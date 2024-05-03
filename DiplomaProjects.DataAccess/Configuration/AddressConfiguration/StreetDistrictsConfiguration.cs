using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class StreetDistrictsConfiguration : IEntityTypeConfiguration<StreetDistrictsEntity>
	{
		public void Configure(EntityTypeBuilder<StreetDistrictsEntity> builder)
		{	
			builder.HasKey(ws => new { ws.StreetsId, ws.DistrictsId });
			
			builder.HasOne(ws => ws.Streets)
				.WithMany(s => s.StreetDistricts)
				.HasForeignKey(ws => ws.StreetsId);

			// Определяем связь с районами
			builder.HasOne(ws => ws.Districts)
				.WithMany(d => d.StreetDistricts)
				.HasForeignKey(ws => ws.DistrictsId);
		}
	}
}
