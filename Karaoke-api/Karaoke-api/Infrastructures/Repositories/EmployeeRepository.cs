using Karaoke_api.AggregateModels.EmployeeAggregates;
using MongoDB.Driver;
namespace Karaoke_api.Infrastructures.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        IMongoCollection<Employee> _employees;
        public EmployeeRepository(IMongoCollection<Employee> employees)
        {
            _employees = employees;
        }
        public Employee AddEmployee(Employee employee)
        {
            _employees.InsertOne(employee);
            return employee;
        }
        public void UpdateEmployee(Employee employee) 
        {
            var EmployDoc = _employees.Find(e => e.Id== employee.Id).FirstOrDefault();
            if (EmployDoc == null) 
            {
                EmployDoc.Update(employee);
                _employees.ReplaceOne(e => e.Id == employee.Id, EmployDoc);
            }
            else
            {
                throw new Exception("Employee doesn't exist in database");
            }    
        }
        public void DeleteEmployee(Employee employee) {
            _employees.DeleteOne(e => e.Id == employee.Id);
        }
    }
}
