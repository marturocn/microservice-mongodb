using MicroServiceMongoDB.Core.ContextMongoDB;
using MicroServiceMongoDB.Core.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServiceMongoDB.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly IAutorContext _autorContext;

        public AutorRepository(IAutorContext autorContext)
        {
            _autorContext = autorContext;
        }

        public async Task<IEnumerable<Autor>> GetAutores()
        {
            return await _autorContext.Autores.Find(p => true).ToListAsync();
        }
    }
}
