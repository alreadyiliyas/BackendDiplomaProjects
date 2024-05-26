using DiplomaProjects.Application.Services.ApplicationsService;
using DiplomaProjects.Contracts.Applications.Request;
using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
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
		private readonly IStatusesServices _statusesService;
		private readonly IUsersService _usersService;
		private readonly IRolesRepository _rolessRepository;
		public ApplicationsController(
			IApplicationsServices applicationsService,
			IStatusesServices statusesService,
			IRolesRepository rolesRepository,
			IUsersService usersService)
		{
			_statusesService = statusesService;
			_applicationsService = applicationsService;
			_rolessRepository = rolesRepository;
			_usersService = usersService;
		}
		[HttpGet("application/getall")]
		public async Task<IActionResult> GetAllApplication()
		{
			try
			{
				var applications = await _applicationsService.GetAllApplications();

				var baseUrl = $"{Request.Scheme}://{Request.Host}/images/";

				applications.ForEach(application =>
				{
					application.ImagePaths = application.ImagePaths
						.Select(path => baseUrl + Path.GetFileName(path))
						.ToList();
				});

				return Ok(applications);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Ошибка сервера: " + ex.Message);
			}
		}

		[HttpGet("application/getByUserGuid")]
		public async Task<IActionResult> GetPersonalApplication(Guid userGuid, string UserRoleName)
		{
			try
			{
				int userId = await _usersService.GetByGuid(userGuid);
				int roleId = await _rolessRepository.GetByRoleName(UserRoleName);

				var personalApplications = await _applicationsService.GetPersonalApplication(userId, roleId);

				var baseUrl = $"{Request.Scheme}://{Request.Host}/images/";

				personalApplications.ForEach(application =>
				{
					application.ImagePaths = application.ImagePaths
						.Select(path => baseUrl + Path.GetFileName(path))
						.ToList();
				});

				return Ok(personalApplications);
			}
			catch (Exception)
			{

				throw new Exception();
			}
		}

		[HttpPost("application/create")]
		public async Task<IActionResult> CreateApplication([FromForm] ApplicationsRequest applicationsRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

			if (!Directory.Exists(uploadPath))
			{
				Directory.CreateDirectory(uploadPath);
			}

			int userId = await _usersService.GetByGuid(applicationsRequest.UserGuid);

			var defaultStatusesId = 1;
			var defaultStatus = await _statusesService.GetdDefaultStatusesAsync(defaultStatusesId);

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
				null, // ModeratorId изначально пустой
				null, // EmployeeId изначально пустой
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

		[HttpPost("application/takejob")]
		public async Task<IActionResult> TakeJob([FromBody] TakeJobRequest takeJobRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			int userId = await _usersService.GetByGuid(takeJobRequest.EmployeeGuid);

			int applicationId = await _applicationsService.TakeJob(takeJobRequest.ApplicationId, takeJobRequest.StatusesId, takeJobRequest.ClientId, userId);

			return Ok(applicationId);
		}
	}
}
