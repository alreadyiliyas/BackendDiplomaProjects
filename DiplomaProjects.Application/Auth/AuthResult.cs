namespace DiplomaProjects.Application.Auth
{
	public class AuthResult
	{
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
		public DateTime Expiration { get; set; }
	}
}
