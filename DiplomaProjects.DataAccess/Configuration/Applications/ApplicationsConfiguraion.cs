using DiplomaProjects.DataAccess.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace DiplomaProjects.DataAccess.Configuration.Applications
{
	public partial class ApplicationsConfiguraion : IEntityTypeConfiguration<ApplicationsEntity>
	{
		public void Configure(EntityTypeBuilder<ApplicationsEntity> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Title)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(e => e.Description)
				.IsRequired()
				.HasMaxLength(1000);

			builder.Property(e => e.CreatedAt)
				.IsRequired();

			builder.Property(e => e.LastModifiedAt)
				.IsRequired();

			// Configure ImagePaths as a JSON column if using a relational database that supports it
			builder.Property(e => e.ImagePaths)
					.HasConversion(
						v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
						v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
					.HasColumnType("json");
		}
	}
}
