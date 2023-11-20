using PPM.Model;


namespace PPM.Domain
{
    public class EmployeeProjectRepo : IEmployeeProject
    {
        public static List<EmployeeProject> projectEmployeeMember = new List<EmployeeProject>();


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

            projectEmployeeMember.Add(employeeProjectObject);
        }





        public  void DeleteEmployeeFromProject(int projectId, int employeeId, out bool employeeDeleted)
        {
            int indexToRemove = projectEmployeeMember.FindIndex(item => item.ProjectId == projectId && item.EmployeeId == employeeId);
            if (indexToRemove >= 0)
            {
                projectEmployeeMember.RemoveAt(indexToRemove);
                employeeDeleted = true;
            }
            else
            {
                employeeDeleted = false;
            }
        }



        public  List<EmployeeProject> GetEmployeeProjects()
        {
            return projectEmployeeMember;
        }






    }

}
