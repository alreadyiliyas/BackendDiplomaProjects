using DiplomaProjects.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.UsersConfiguration
{
    public partial class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();

            builder.HasOne(u => u.UserRole)
                .WithMany()
                .HasForeignKey(u => u.UserRoleId)
                .IsRequired();
        }
    }
}
