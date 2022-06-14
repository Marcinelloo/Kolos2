// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using kolos2.DTOs;
// using kolos2.Entities.Models;
// using kolos2.Services;
// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using System.Transactions;

// namespace kolos2.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ClientsController : ControllerBase
//     {

//         private readonly IRepoService _service;

//         public ClientsController(IRepoService service)
//         {
//             _service = service;
//         }

//         [HttpPost("{clientId}/orders")]
//         public async Task<IActionResult> Create(int clientId, ZamowieniePost body)
//         {

//             if (!ModelState.IsValid)
//                 return BadRequest("Niepoprawne ciało żądania!");

//             if (await _service.GetClientById(clientId).FirstOrDefaultAsync() is null)
//                 return NotFound("Nie znaleziono klienta o podanym id");

//             if (await _service.GetEmployeeById(body.IdPracownik).FirstOrDefaultAsync() is null)
//                 return NotFound("Nie znaleziono pracownika o podanymn id");

//             using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
//             {
//                 try
//                 {
//                     var zamowienie = new Zamowienie
//                     {
//                         DataPrzyjecia = body.DataPrzyjecia,
//                         Uwagi = body.Uwagi,
//                         IdKlient = clientId,
//                         IdPracownik = body.IdPracownik
//                     };
//                     await _service.CreateAsync(zamowienie);
//                     await _service.SaveChangesAsync();

//                     foreach (var wyrob in body.Wyroby)
//                     {
//                         if (await _service.GetConfectioneryById(wyrob.IdWyrobu).FirstOrDefaultAsync().ConfigureAwait(false) is null)
//                             return NotFound($"Nie znaleziono wyrobu -- ID: {wyrob.IdWyrobu}");

//                         await _service.CreateAsync(new ZamowienieWyrobCukierniczy
//                         {
//                             IdWyrobuCukierniczego = wyrob.IdWyrobu,
//                             IdZamowienia = zamowienie.IdZamowienia,
//                             Ilosc = wyrob.Ilosc,
//                             Uwagi = wyrob.Uwagi
//                         });
//                     }

//                     scope.Complete();

//                 }
//                 catch (Exception)
//                 {
//                     return Problem("Nieoczekiwany błąd serwera");
//                 }
//             }
//             await _service.SaveChangesAsync();

//             return NoContent();
//         }

//         [HttpDelete("{clientId}")]
//         public async Task<IActionResult> Delete(int clientId, ZamowieniePost body)
//         {

//             if (!ModelState.IsValid)
//                 return BadRequest("Niepoprawne ciało żądania!"); // check czy git chyba ze bedzie id


//             // var doctor = await _service.GetDoctorById(id);

//             // if (doctor == null) return NotFound();

//             // if (!(await _service.DeleteDoctor(doctor)))
//             //     return BadRequest();

//             // await _service.SaveDatabase();
//             // return Ok();

//             //             Customer customer = new Customer () { Id = id };
//             // context.Customers.Attach(customer);
//             // context.Customers.Remove(customer);
//             // context.SaveChanges();

//             if (await _service.GetClientById(clientId).FirstOrDefaultAsync() is null) // sprawdzamy czy cos w ogole isnieje
//                 return NotFound("Nie znaleziono klienta o podanym id");

//             if (await _service.GetEmployeeById(body.IdPracownik).FirstOrDefaultAsync() is null)
//                 return NotFound("Nie znaleziono pracownika o podanymn id");

//             using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
//             {

//                 try
//                 {
//                     var zamowienie = new Zamowienie
//                     {
//                         DataPrzyjecia = body.DataPrzyjecia,
//                         Uwagi = body.Uwagi,
//                         IdKlient = clientId,
//                         IdPracownik = body.IdPracownik
//                     };
//                     await _service.CreateAsync(zamowienie);
//                     await _service.SaveChangesAsync();

//                     foreach (var wyrob in body.Wyroby)
//                     {
//                         if (await _service.GetConfectioneryById(wyrob.IdWyrobu).FirstOrDefaultAsync().ConfigureAwait(false) is null)
//                             return NotFound($"Nie znaleziono wyrobu -- ID: {wyrob.IdWyrobu}");

//                         await _service.CreateAsync(new ZamowienieWyrobCukierniczy
//                         {
//                             IdWyrobuCukierniczego = wyrob.IdWyrobu,
//                             IdZamowienia = zamowienie.IdZamowienia,
//                             Ilosc = wyrob.Ilosc,
//                             Uwagi = wyrob.Uwagi
//                         });
//                     }

//                     scope.Complete();

//                 }
//                 catch (Exception)
//                 {
//                     return Problem("Nieoczekiwany błąd serwera");
//                 }
//             }
//             await _service.SaveChangesAsync();

//             return NoContent();
//         }
//     }
// }
