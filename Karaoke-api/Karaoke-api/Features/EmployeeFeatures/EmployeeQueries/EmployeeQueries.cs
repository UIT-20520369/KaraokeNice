using Karaoke_api.AggregateModels.EmployeeAggregates;
using Karaoke_api.AggregateModels.RoleAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.EmployeeFeatures.EmployeeQueries
{
    [ExtendObjectType(name: "Query")]
    public class EmployeeQueries
    {
        [UseFiltering]
        [UseSorting]
        public IExecutable<Employee> GetEmployees([Service] IMongoCollection<Employee> collection, [Service] IMongoCollection<Role> roleCollection) {
            return collection.Aggregate().Lookup<Employee,Role,Employee>(roleCollection
                , e => e.RoleId
                , r => r.Id
                , o => o.Role).Unwind<Employee,Employee>(o=>o.Role).AsExecutable();
        }

        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IExecutable<Employee> GetEmployeesWithPagination([Service] IMongoCollection<Employee> collection, [Service] IMongoCollection<Role> roleCollection)
        {
            return collection.Aggregate().Lookup<Employee, Role, Employee>(roleCollection
                , e => e.RoleId
                , r => r.Id
                , o => o.Role).Unwind<Employee, Employee>(o => o.Role).AsExecutable();
        }
    }
}
