using DiplomaProjects.Contracts;
using DiplomaProjects.Contracts.Users;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions;
using DiplomaProjects.Core.Models.UsersModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.UsersControllers
{
	[Route("api/")]
	[ApiController]
	public class UserInfoController : ControllerBase
	{
		private readonly IUsersInfoServices _usersInfoServices;
		public UserInfoController(IUsersInfoServices usersInfoServices)
		{
			_usersInfoServices = usersInfoServices;
		}
		[HttpGet("userinfo")]
		public async Task<IActionResult> GetAllUsersInfo()
		{
			var usersInfo = await _usersInfoServices.GetAllUsersInfo();
			return Ok(usersInfo);
		}
		[HttpPost("userinfo")]
		public async Task<IActionResult> AddUserInfo([FromBody] UserInfoRequest userInfoRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var (userInfo, error) = UserInfo.Create(
				userInfoRequest.UserId, 
				userInfoRequest.Surname, 
				userInfoRequest.Name, 
				userInfoRequest.BirthDate, 
				userInfoRequest.PhoneNumber, 
				userInfoRequest.IdentityNumberKZT,
				DateTime.Now,
				DateTime.Now
				);
			if (!string.IsNullOrEmpty(error))
			{
				return BadRequest(new Response("401", error));
			}

			var result = await _usersInfoServices.AddUserInfo(userInfo);
			if (result != -1)
			{
				return Ok(result); 
			}
			else
			{
				return BadRequest(new Response("400", "Не получилось добавить информацию о пользователе!"));
			}
			}
	}
}
