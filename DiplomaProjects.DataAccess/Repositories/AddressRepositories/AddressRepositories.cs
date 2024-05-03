using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.Core.Models.AddressModels;
using DiplomaProjects.DataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProjects.DataAccess.Repositories.AddressRepositories
{
	public class AddressRepositories<T> : IAddressRepositories<T>
	{
		private readonly DiplomaDbContext _context;

		public AddressRepositories(DiplomaDbContext context)
		{
			_context = context;
		}

		public async Task<int> Create(T entity)
		{
			if (typeof(T) == typeof(Countries))
			{
				var countryEntity = new CountriesEntity
				{
					CountriesName = ((Countries)(object)entity).CountriesName
				};

				await _context.Countries.AddAsync(countryEntity);
				await _context.SaveChangesAsync();

				return countryEntity.Id;
			}
			// Добавьте другие типы, если они поддерживаются репозиторием
			else
			{
				throw new ArgumentException($"Type {typeof(T)} is not supported by this repository.");
			}
		}

		public async Task<List<T>> GetAll()
		{
			if (typeof(T) == typeof(Countries))
			{
				var countriesEntity = await _context.Countries.AsNoTracking().ToListAsync();

				var countries = countriesEntity
					.Select(c => Countries.Create(c.Id, c.CountriesName).countries)
					.Cast<T>()
					.ToList();

				return countries;
			}
			// Добавьте другие типы, если они поддерживаются репозиторием
			else
			{
				throw new ArgumentException($"Type {typeof(T)} is not supported by this repository.");
			}
		}

		//public async Task<List<T>> GetById(int id)
		//{
		//	// Реализация метода получения объекта по id
		//}
	}

}
