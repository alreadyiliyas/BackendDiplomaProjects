using DiplomaProjects.Core.Models.ApplicationsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProjects.Core.Abstractions.ServicesAbstractions.ApplicationsAbstractions
{
	public interface IApplicationsServices
	{
		Task<int> CreateApplication(Applications applications);
		Task<List<Applications>> GetAllApplications();
	}
}
