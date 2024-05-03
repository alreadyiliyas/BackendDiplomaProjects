namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
	public interface IAddressRepositories<T>
	{
		Task<List<T>> GetAll();
		//Task<List<T>> GetById(int id);
		Task<int> Create(T entity);
	}
}
