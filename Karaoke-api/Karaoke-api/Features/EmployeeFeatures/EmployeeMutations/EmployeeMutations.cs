using Karaoke_api.AggregateModels.EmployeeAggregates;
using Karaoke_api.Infrastructures.Repositories;

namespace Karaoke_api.Features.EmployeeFeatures.EmployeeMutations
{
    [ExtendObjectType(name: "Mutation")]
    public class EmployeeMutations
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeMutations(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public string CreateEmployee(string name, string address, int countshift,string gender, string phone,string roleId)
        {
            var employee= new Employee(name, address,gender,phone,roleId,countshift);
            var temp = employeeRepository.AddEmployee(employee);
            return temp.Id;
        }

        public string UpdateEmployee(string id, string? name, string? address, int? countshift, string? gender, string? phone, string? roleId)
        {
            var employee = new Employee(name, address, gender, phone, roleId, countshift,id);
            employeeRepository.UpdateEmployee(employee);
            return employee.Id;

        }
        public string DeleteEmployee(string id, string? name, string? address, int? countshift, string? gender, string? phone, string? roleId)
        {
            var employee = new Employee(name, address, gender, phone, roleId, countshift, id);
            employeeRepository.DeleteEmployee(employee);
            return employee.Id;

        }
    }
}
