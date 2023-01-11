using Lipy.HeaderApi.Model;
using MongoDB.Bson.Serialization;

namespace Lipy.HeaderApi.Persistence
{
    public class HeaderMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Header>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Title).SetIsRequired(true);
                map.MapMember(x => x.Link).SetIsRequired(true);

            });
        }
    }
}
