using DiplomaProjects.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration
{
	public partial class UserConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.UserName).IsRequired();
			builder.Property(x => x.Email).IsRequired();
			builder.Property(x => x.PasswordHash).IsRequired();

			builder.HasOne(u => u.UserRole)
				.WithMany()
				.HasForeignKey(u => u.UserRoleId)
				.IsRequired();
		}
	}
}
