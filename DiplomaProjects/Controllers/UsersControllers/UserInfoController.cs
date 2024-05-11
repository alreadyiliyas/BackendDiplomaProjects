using DiplomaProjects.Contracts.Users;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions;
using DiplomaProjects.Core.Models.UsersModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.UsersControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserInfoController : ControllerBase
	{
		private readonly IUsersInfoServices _usersInfoServices;
		public UserInfoController(IUsersInfoServices usersInfoServices)
		{
			_usersInfoServices = usersInfoServices;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllUsersInfo()
		{
			var usersInfo = await _usersInfoServices.GetAllUsersInfo();
			return Ok(usersInfo);
		}
		[HttpPost]
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
				return BadRequest(error);
			}

			var result = await _usersInfoServices.AddUserInfo(userInfo);
			if (result != -1)
			{
				return Ok(result); 
			}
			else
			{
				return BadRequest("Не получилось добавить информацию о пользователе!");
			}
		}
	}
}
