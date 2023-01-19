using MongoDB.Driver;
using Karaoke_api.AggregateModels.UserAggregates;

namespace Karaoke_api.Features.UserFeatures.UserQueries
{
    [ExtendObjectType(name: "Query")]
    public class UserQueries
    {
        [UseFirstOrDefault]
        [UseFiltering]
        public IExecutable<User> GetUser([Service] IMongoCollection<User> collection)
        => collection.AsExecutable();
    }
}
