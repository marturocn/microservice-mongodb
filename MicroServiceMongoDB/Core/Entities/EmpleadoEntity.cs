using MongoDB.Bson.Serialization.Attributes;

namespace MicroServiceMongoDB.Core.Entities
{
    [BsonCollection("Empleado")]
    public class EmpleadoEntity : Document
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("puesto")]
        public string Puesto { get; set; }
    }
}
