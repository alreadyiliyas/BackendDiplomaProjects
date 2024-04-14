namespace DiplomaProjects.Infrastructure.Authentication
{
	public class JwtOptions
	{
		public string Secret { get; set; } = string.Empty;
		public int TokenValidityInMinutes { get; set; }
		public int RefreshTokenValidityInDays { get; set; }
	}
}
