using DiplomaProjects.Application.Services.ApplicationsService;
using DiplomaProjects.Contracts.Applications.Request;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions;
using DiplomaProjects.Core.Models.ApplicationsModels;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProjects.Controllers.ApplicationsControllers
{
	[ApiController]
	[Route("api/")]
	public class ApplicationsController : ControllerBase
	{
		private readonly IApplicationsServices _applicationsService;
		private readonly IUsersService _usersService;
		public ApplicationsController(IApplicationsServices applicationsService, IUsersService usersService)
		{
			_applicationsService = applicationsService;
			_usersService = usersService;
		}
		[HttpGet("application/getall")]
		public async Task<IActionResult> GetAllApplication() 
		{
			try
			{
				var applications = await _applicationsService.GetAllApplications();
				return Ok(applications);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Ошибка сервера: " + ex.Message);
			}
		}
		
		[HttpPost("application/create")]
		public async Task<IActionResult> CreateApplication([FromForm] ApplicationsRequest applicationsRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			int userId = await _usersService.GetByGuid(applicationsRequest.UserGuid);
			string uploadPath = @"C:\Users\User\source\Session\DiplomaProjects\DiplomaProjects\images";

			int defaultStatus = 1; // Статус создан, создается автоматически при создании заявки

			// Create a list to store the image paths
			var imagePaths = new List<string>();

			// Save files to the server
			if (applicationsRequest.Files != null && applicationsRequest.Files.Count > 0)
			{
				foreach (var file in applicationsRequest.Files)
				{
					if (file.Length > 0)
					{
						Console.WriteLine($"Загружается файл: {file.FileName}");
						var filePath = Path.Combine(uploadPath, Path.GetRandomFileName() + Path.GetExtension(file.FileName));
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await file.CopyToAsync(stream);
						}
						imagePaths.Add(filePath);
					}
				}
			}

			var (applications, error) = Applications.Create(
				0,
				applicationsRequest.Title,
				applicationsRequest.Description,
				defaultStatus,
				userId,
				null,
				null,
				DateTime.Now,
				DateTime.Now,
				imagePaths);

			if (!string.IsNullOrEmpty(error))
			{
				return BadRequest(error);
			}

			var res = await _applicationsService.CreateApplication(applications);

			if (res != -1)
			{
				return Ok(res);
			}
			else
			{
				return BadRequest("Не получилось создать заявку!");
			}
		}
	}
}
