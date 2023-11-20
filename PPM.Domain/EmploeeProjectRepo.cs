using PPM.Dal;
using PPM.Model;


namespace PPM.Domain
{
    public class EmployeeProjectRepo : IEmployeeProject
    {
     

        EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();


        public  void EmployeeToProject(int projectId, string projectName,  int employeeId, string employeeFirstName, string employeeLastName, int roleId)
        {
            EmployeeProject employeeProjectObject = new EmployeeProject()
            {
                ProjectId = projectId,
                ProjectName = projectName,
                EmployeeId = employeeId,
                EmployeeFirstName = employeeFirstName,
                EmployeeLastName = employeeLastName,
                RoleId = roleId
            };

            employeeProjectDal.AddEmployeeProjectDal(employeeProjectObject);
        }





        public  void DeleteEmployeeFromProject(int projectId, int employeeId)
        {
           employeeProjectDal.DeleteEmployeeProjectDal(projectId, employeeId);
        }



        public  List<EmployeeProject> GetEmployeeProjects()
        {
            var projectEmployeeMember = employeeProjectDal.GetEmployeeProjectsDal();
            return projectEmployeeMember;
        }






    }

}
