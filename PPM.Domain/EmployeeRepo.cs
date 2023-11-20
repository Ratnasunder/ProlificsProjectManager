using PPM.Model;
using PPM.Dal;

namespace PPM.Domain
{
    public class EmployeeRepo : IEntityOperation<Employee>
    {


       
        EmployeeDal employeeDal = new EmployeeDal();
        public  void Add(Employee employee)
        {
            employeeDal.AddEmployeeDal(employee);
        
         
        }
        public List<Employee> Get()
        {
            var employeeList = employeeDal.GetEmployeeDal();
            return employeeList;
        }

        public  Employee ViewById(int employeeId)
        {
           var viewEmployeetById = employeeDal.ViewByIdEmployee(employeeId);
            return viewEmployeetById;
        }

        public  void Delete(int deleteId)
        {
            employeeDal.DeleteEmployeetDal(deleteId);
        }


    }
}