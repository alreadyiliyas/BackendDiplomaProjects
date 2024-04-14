namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
	public interface IRolesRepository
	{
		Task<int> GetByRoleName(string roleName);
	}
}
