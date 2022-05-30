using MicroServiceMongoDB.Core.Entities;
using MicroServiceMongoDB.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServiceMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;
        private readonly IMongoRepository<EmpleadoEntity> _empleadoGenericoRepository;

        public LibreriaController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> autorGenericoRepository, IMongoRepository<EmpleadoEntity> empleadoGenericoRepository)
        {
            _autorRepository = autorRepository;
            _autorGenericoRepository = autorGenericoRepository;
            _empleadoGenericoRepository = empleadoGenericoRepository;
        }

        [HttpGet("empleadoGenerico")]
        public async Task<ActionResult<IEnumerable<EmpleadoEntity>>> GetEmpleadoGenerico()
        {
            var empleados = await _empleadoGenericoRepository.GetAll();
            return Ok(empleados);
        }

        [HttpGet("autorGenerico")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutorGenerico()
        {
            var autores = await _autorGenericoRepository.GetAll();
            return Ok(autores);
        }

        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorRepository.GetAutores();
            return Ok(autores);
        }
    }
}
