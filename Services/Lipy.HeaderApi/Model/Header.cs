using Lipy.HeaderApi.Model.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lipy.HeaderApi.Model
{
    public class Header : BaseEntity
    {
        public Header(string title,string link) : base()
        {
            base.Id = Guid.NewGuid();
            base.CreatedOn = DateTime.Now;
            Title = title;
            Link = link;
            base.LastChangedOn = null;
        } 
        public Header(Guid id,string title,string link) : base()
        {
            base.Id = id;
            Title = title;
            Link = link;
            base.LastChangedOn = DateTime.Now;
        }
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Title { get; set; }
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Link { get; set; }
    }
}
