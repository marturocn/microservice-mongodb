using MicroServiceMongoDB.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServiceMongoDB.Repository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutores();
    }
}
