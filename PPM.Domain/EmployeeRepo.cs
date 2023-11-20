using PPM.Model;

namespace PPM.Domain
{
    public class EmployeeRepo : IEntityOperation<Employee>
    {


        public static List<Employee> employeeList = new List<Employee>();

        public  void Add(Employee employee)
        {
        
            employeeList.Add(employee);
        }
        public List<Employee> Get()
        {
            return employeeList;
        }

        public  Employee ViewById(int employeeId)
        {
            var viewEmployeetById = employeeList.FirstOrDefault(p => p.EmployeeId == employeeId);
            return viewEmployeetById;
        }

        public  void Delete(int deleteId)
        {
            employeeList.RemoveAll(item => item.EmployeeId == deleteId);
        }


    }
}