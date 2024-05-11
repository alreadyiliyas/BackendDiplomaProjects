﻿using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.AddressConfiguration
{
	public partial class AddressOfHouseConfiguration : IEntityTypeConfiguration<AddressOfHouseEntity>
	{
		public void Configure(EntityTypeBuilder<AddressOfHouseEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.HouseNumber).IsRequired();
			builder.Property(x => x.ApartmentNumber).IsRequired();

			builder.HasOne(x => x.Streets).WithMany().HasForeignKey(x => x.StreetsId).IsRequired();
			builder.HasOne(x => x.MicroDistricts).WithMany().HasForeignKey(x => x.MicroDistrictsId).IsRequired();

			builder.HasOne(x => x.User)
				.WithMany()
				.HasForeignKey(x => x.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
