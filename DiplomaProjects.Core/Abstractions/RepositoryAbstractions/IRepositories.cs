namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
    public interface IRepositories<T> where T : class
    {
        bool Add(T model);
        bool Update(T model);
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Delete(T model);
    }
}
