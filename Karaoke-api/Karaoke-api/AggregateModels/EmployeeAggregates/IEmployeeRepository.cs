using Karaoke_api.AggregateModels.Seedwork;
namespace Karaoke_api.AggregateModels.EmployeeAggregates
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        public Employee AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(Employee employee);
    }
}
