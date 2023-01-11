using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;

namespace Lipy.HeaderApi.Persistence
{
    public static class HeaderDbPersistence
    {
        public static void Configure()
        {
            HeaderMap.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            
            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
