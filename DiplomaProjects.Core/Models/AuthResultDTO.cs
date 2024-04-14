namespace DiplomaProjects.Core.DTOs
{
	public class AuthResultDTO
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public DateTime Expiration { get; set; }
	}
}