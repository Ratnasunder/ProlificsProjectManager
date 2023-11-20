namespace PPM.Model
{
    public interface IEmployeeProject
    {
        public void EmployeeToProject(int projectId, string projectName, int employeeId, string employeeFirstName, string employeeLastName, int roleId);
        public void DeleteEmployeeFromProject(int projectId, int employeeId);
        public  List<EmployeeProject> GetEmployeeProjects();

    }
}