﻿using DiplomaProjects.Core.Models.ApplicationsModels;
namespace DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions
{
	public interface IApplicationsServices
	{
		Task<int> CreateApplication(Applications applications);
		Task<List<Applications>> GetAllApplications();
	}
}
