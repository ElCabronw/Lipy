using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lipy.HeaderApi.Model.Base
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonRequired]
        public DateTime CreatedOn { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? LastChangedOn { get; set; }
    }
}
