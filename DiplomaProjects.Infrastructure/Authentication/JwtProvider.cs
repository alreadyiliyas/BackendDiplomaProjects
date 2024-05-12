using BookStore.Infrastructure.Authentication;
using DiplomaProjects.Application.Auth;
using DiplomaProjects.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DiplomaProjects.Infrastructure.Authentication
{
	public class JwtProvider : IJwtProvider
	{
		private readonly JwtOptions _options;
		
		public JwtProvider(IOptions<JwtOptions> options)
		{
			_options = options.Value;
		}
		public string GenerateToken(User user)
		{
			Claim[] claims = new Claim[]
			{
				new Claim(ClaimTypes.Name, user.Email.ToString()),
				new Claim(CustomClaims.UserGuid, user.GuidUserId.ToString()),
				new Claim(CustomClaims.UserRole, user.UserRoleName.ToString()),
			};

			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
				SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				expires: DateTime.Now.AddMinutes(_options.TokenValidityInMinutes),
				claims: claims,
				signingCredentials: signingCredentials
				);

			var tokenHandler = new JwtSecurityTokenHandler();
			return tokenHandler.WriteToken(token);
		}
		public string GenerateRefreshToken()
		{
			var randomNumber = new byte[64];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
		public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = false,
				ValidateIssuer = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
				ValidateLifetime = false
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
			if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				throw new SecurityTokenException("Invalid token");

			return principal;
		}
	}
}
