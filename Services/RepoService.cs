// using Microsoft.EntityFrameworkCore;
// using kolos2.Entities;
// using kolos2.Entities.Models;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace kolos2.Services
// {
//     public class RepoService : IRepoService
//     {
//         private readonly RepositoryContext _repository;
//         public RepoService(RepositoryContext repository)
//         {
//             _repository = repository;
//         }
//         public IQueryable<Zamowienie> GetAllOrders()
//         {
//             return _repository.Zamowienie
//                 .Include(e => e.Klient)
//                 .Include(e => e.ZamowieniaWyrobCukierniczy)
//                 .ThenInclude(e => e.WyrobCukierniczy);
//         }

//         public IQueryable<Zamowienie> GetAllOrdersByClientName(string clientName)
//         {
//             return _repository.Zamowienie
//                 .Include(e => e.Klient)
//                 .Where(e => e.Klient.Nazwisko == clientName)
//                 .Include(e => e.ZamowieniaWyrobCukierniczy)
//                 .ThenInclude(e => e.WyrobCukierniczy);
//         }

//         public IQueryable<Klient> GetClientById(int id)
//         {
//             return _repository.Klient.Where(e => e.IdKlient == id);
//         }

//         public IQueryable<WyrobCukierniczy> GetConfectioneryById(int id)
//         {
//             return _repository.WyrobCukierniczy.Where(e => e.IdWyrobuCukierniczego == id);
//         }

//         public IQueryable<Pracownik> GetEmployeeById(int id)
//         {
//             return _repository.Pracownik.Where(e => e.IdPracownik == id);
//         }

//         public async Task CreateAsync<T>(T entity) where T : class
//         {
//             await _repository.Set<T>().AddAsync(entity);
//         }

//         public async Task SaveChangesAsync()
//         {
//             await _repository.SaveChangesAsync();
//         }
//     }
// }
