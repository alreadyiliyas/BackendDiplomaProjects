using DiplomaProjects.DataAccess.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProjects.DataAccess.Configuration.Applications
{
	public partial class ApplicationsConfiguraion : IEntityTypeConfiguration<ApplicationsEntity>
	{
		public void Configure(EntityTypeBuilder<ApplicationsEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Title).IsRequired();

			// Связь с клиентом
			builder.HasOne(x => x.Client)
				   .WithMany()
				   .HasForeignKey(x => x.ClientId) // Предположим, что в ApplicationsEntity есть свойство ClientId
				   .IsRequired();

			// Связь с модератором
			builder.HasOne(x => x.Moderator)
				   .WithMany()
				   .HasForeignKey(x => x.ModeratorId) // Предположим, что в ApplicationsEntity есть свойство ModeratorId
				   .IsRequired(false); // Модератор может быть не назначен

			// Связь с сотрудником
			builder.HasOne(x => x.Employee)
				   .WithMany()
				   .HasForeignKey(x => x.EmployeeId) // Предположим, что в ApplicationsEntity есть свойство EmployeeId
				   .IsRequired(false); // Сотрудник может быть не назначен
		}
	}
}
