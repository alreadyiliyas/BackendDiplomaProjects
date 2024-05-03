using DiplomaProjects.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.UsersConfiguration
{
	public partial class UserInfoConfiguration : IEntityTypeConfiguration<UserInfoEntity>
	{
		public void Configure(EntityTypeBuilder<UserInfoEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.PhoneNumber).IsRequired();
			builder.Property(x => x.IdentityNumberKZT).IsRequired();

			builder.HasOne(x => x.User)
				.WithOne()
				.HasForeignKey<UserInfoEntity>(x => x.Id)
				.OnDelete(DeleteBehavior.Cascade)
				.IsRequired();

			builder.HasOne(x => x.AddressOfHouse)
				.WithMany()
				.HasForeignKey(x => x.AddressId)
				.OnDelete(DeleteBehavior.Cascade)
				.IsRequired();

		}
	}
}
