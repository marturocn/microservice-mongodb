using MicroServiceMongoDB.Core.Entities;
using MongoDB.Driver;

namespace MicroServiceMongoDB.Core.ContextMongoDB
{
    public interface IAutorContext
    {
        IMongoCollection<Autor> Autores { get; }
    }
}
