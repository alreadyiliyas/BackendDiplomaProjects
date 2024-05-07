using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;

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

		public T GetById(int id)
		{
			return _entity.Find(id);
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
	}
}
