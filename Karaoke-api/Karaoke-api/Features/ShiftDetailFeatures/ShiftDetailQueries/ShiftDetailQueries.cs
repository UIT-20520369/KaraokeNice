using Karaoke_api.AggregateModels.ShiftAggregates;
using Karaoke_api.AggregateModels.ShiftDetailAggregates;
using Karaoke_api.AggregateModels.EmployeeAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Features.ShiftDetailFeatures.ShiftDetailQueries
{
    [ExtendObjectType(name: "Query")]
    public class ShiftDetailQueries
    {
        private AggregateUnwindOptions<ShiftDetail> _options;
        public ShiftDetailQueries()
            {
                _options = new()
                {
                    PreserveNullAndEmptyArrays = true,
                };
            }
        [UseFiltering]
        [UseSorting]
        public IExecutable<ShiftDetail> GetShiftDetails([Service] IMongoCollection<ShiftDetail> collection, [Service] IMongoCollection<Employee> employeeCollection, [Service] IMongoCollection<Shift> shiftCollection)
        {
            return collection.Aggregate().Lookup<ShiftDetail, Employee, ShiftDetail>(employeeCollection
                , c => c.EmployeeId
                , d => d.Id
                , e => e.Employee).Unwind<ShiftDetail, ShiftDetail>(u => u.Employee)
                .Lookup<ShiftDetail, Shift, ShiftDetail>(shiftCollection
                , c => c.ShiftId
                , s => s.Id
                , r => r.Shifting).Unwind<ShiftDetail,ShiftDetail>(c => c.Shifting).AsExecutable();
        }

        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IExecutable<ShiftDetail> GetShiftDetailsWithPagination([Service] IMongoCollection<ShiftDetail> collection, [Service] IMongoCollection<Employee> employeeCollection, [Service] IMongoCollection<Shift> shiftCollection)
        {
            return collection.Aggregate().Lookup<ShiftDetail, Employee, ShiftDetail>(employeeCollection
                  , c => c.EmployeeId
                  , d => d.Id
                  , e => e.Employee).Unwind<ShiftDetail, ShiftDetail>(u => u.Employee)
                  .Lookup<ShiftDetail, Shift, ShiftDetail>(shiftCollection
                  , c => c.ShiftId
                  , s => s.Id
                  , r => r.Shifting).Unwind(c => c.Shifting,options:_options).AsExecutable();
        }
    }
}
