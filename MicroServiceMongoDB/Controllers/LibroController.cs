using MicroServiceMongoDB.Core.Entities;
using MicroServiceMongoDB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMongoRepository<LibroEntity> _libroRepository;

        public LibroController(IMongoRepository<LibroEntity> libroRepository)
        {
            _libroRepository = libroRepository;
        }

        [HttpPost]
        public async Task Post(LibroEntity libro)
        {
            await _libroRepository.InsertDocument(libro);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroEntity>>> Get()
        {
            return Ok(await _libroRepository.GetAll());
        }

        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<LibroEntity>>> PostPagination(PaginationEntity<LibroEntity> pagination)
        {
            var result = await _libroRepository.PaginationByFilter(pagination);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroEntity>> GetById(string Id)
        {
            var libro = await _libroRepository.GetById(Id);
            return Ok(libro);
        }
    }
}
