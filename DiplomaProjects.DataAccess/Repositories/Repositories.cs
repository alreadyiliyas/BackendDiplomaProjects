using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiplomaProjects.DataAccess.Repositories
{
	public class Repositories<T> : IRepositories<T> where T : class
	{
		private DiplomaDbContext _diplomaDbContext;
		DbSet<T> _entity = null;
		public Repositories(DiplomaDbContext diplomaDbContext)
		{
			_diplomaDbContext = diplomaDbContext;
			_entity = _diplomaDbContext.Set<T>();
		}
		public bool Add(T model)
		{
			try
			{
				_entity.Add(model);
				_diplomaDbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool Delete(T model)
		{
			try
			{
				_entity.Remove(model);
				_diplomaDbContext.SaveChanges();
				return true;

			}
			catch (Exception ex)
			{

				return false;
			}
		}

		public IEnumerable<T> GetAll()
		{
			return _entity.ToList();
		}

		public bool Update(T model)
		{
			try
			{
				_entity.Update(model);
				_diplomaDbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public T GetById(int id)
		{
			return _entity.Find(id);
		}
		public async Task<List<TReturn>> GetQueryDataAsync<TReturn>(
											Expression<Func<T, bool>> whereExp,
											Expression<Func<T, TReturn>> selectExp,
											Expression<Func<T, TReturn>> orderExp = null,
											bool? descending = null,
											params Expression<Func<T, object>>[] includeExps)
		{
			IQueryable<T> query = _diplomaDbContext.Set<T>();

			if (whereExp != null)
			{
				query = query.Where(whereExp);
			}

			if (orderExp != null)
			{
				if (descending.HasValue)
				{
					query = descending.Value ? query.OrderByDescending(orderExp) : query.OrderBy(orderExp);
				}
				else
				{
					query = query.OrderBy(orderExp);
				}
			}

			foreach (Expression<Func<T, object>> navigationProperty in includeExps)
			{
				query = query.Include(navigationProperty);
			}

			return await query.Select(selectExp).ToListAsync();
		}

		public IEnumerable<T> GetAllRegionsByCountryId(int countryId)
		{
			return _entity.Where(r => EF.Property<int>(r, "CountriesId") == countryId).ToList();
		}
	}
}
