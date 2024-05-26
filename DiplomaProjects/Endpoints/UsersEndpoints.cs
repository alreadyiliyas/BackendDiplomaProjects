using DiplomaProjects.Contracts.Users;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions;

namespace DiplomaProjects.Endpoints
{
    public static class UsersEndpoints
	{

		public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("register", async (RegisterUserRequest request, IUsersService usersService) =>
			{
				try
				{
					var userId = await usersService.Register(request.UserName, request.Email, request.Password, request.UserRoleName);
					return Results.Ok(new
					{
						UserId = userId,
						message = "Пользователь успешно создан!"
					});
				}
				catch (Exception ex)
				{
					return Results.BadRequest(ex.Message);
				}
			}).Accepts<RegisterUserRequest>("application/json");

			app.MapPost("login", async (LoginUserRequest request, IUsersService usersService) =>
			{
				try
				{
					var authResult = await usersService.Login(request.Email, request.Password);
					return Results.Ok(new
					{
						authResult.AccessToken,
						authResult.RefreshToken,
						authResult.Expiration
					});
				}
				catch (Exception ex)
				{
					return Results.BadRequest(ex.Message);
				}
			});

			app.MapPost("refresh-token", async (RefreshToken request, IUsersService usersService) =>
			{
				try
				{
					var refreshTokenResult = await usersService.GetRefreshToken(request.AccessTokenReq, request.RefreshTokenReq);
					return Results.Ok(new
					{
						refreshTokenResult.AccessToken, 
						refreshTokenResult.RefreshToken
					});
				}
				catch (Exception ex)
				{
					return Results.BadRequest(ex.Message);
				}
			});
			return app;
		}
	}
}
