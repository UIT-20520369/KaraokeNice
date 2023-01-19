using Karaoke_api.AggregateModels.Seedwork;
using System.Reflection;

namespace Karaoke_api.AggregateModels.EmployeeAggregates
{
    public class Employee:IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string RoleId { get; set; }
        public int CountShift { get; set; }
        public Employee() { }
        public Employee(string id, string name, string address, string gender, string phone, string roleId, int countShift)
        {
            Id = id;
            Name = name;
            Address = address;
            Gender = gender;
            Phone = phone;
            RoleId = roleId;
            CountShift = countShift;
        }
        public void Update(Employee employee)
        {
            foreach (var item in employee.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(employee).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(employee).ToString() == "0") continue;
                if (item.GetValue(employee) == null) continue;

                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(employee));
            }
        }
    }
}
