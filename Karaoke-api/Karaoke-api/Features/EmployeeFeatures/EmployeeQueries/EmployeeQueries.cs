using Karaoke_api.AggregateModels.EmployeeAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.EmployeeFeatures.EmployeeQueries
{
    [ExtendObjectType(name: "Query")]
    public class EmployeeQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<Employee> GetEmployees([Service] IMongoCollection<Employee> collection) {
            return collection.AsExecutable();
        }
    }
}
