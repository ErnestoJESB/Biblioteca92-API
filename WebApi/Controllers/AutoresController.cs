using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AutoresController : Controller
    {
        private readonly IAutorServices _autorServices;

        public AutoresController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            var response = await _autorServices.GetAutores();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor(Autor autor)
        {
            return Ok(await _autorServices.Crear(autor));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAutor(Autor autor)
        {
            return Ok(await _autorServices.UpdateAutor(autor));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAutor(int PKAutor)
        {
            return Ok(await _autorServices.DeleteAutor(PKAutor));
        }

        [HttpGet("{PKAutor}")]
        public async Task<IActionResult> GetIdAutor(int PKAutor)
        {
            var response = await _autorServices.GetIdAutor(PKAutor);
            return Ok(response);
        }
        
    }
}
