using System.Linq.Expressions;

namespace DiplomaProjects.Core.Abstractions.RepositoryAbstractions
{
    public interface IRepositories<T> where T : class
    {
        bool Add(T model);
        bool Update(T model);
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Delete(T model);
		IEnumerable<T> GetAllRegionsByCountryId(int countryId);
		Task<List<TReturn>> GetQueryDataAsync<TReturn>(Expression<Func<T, bool>> whereExp,
																Expression<Func<T, TReturn>> selectExp,
																Expression<Func<T, TReturn>> orderExp = null,
																bool? descending = null,
																params Expression<Func<T, object>>[] includeExps);
	}
}
