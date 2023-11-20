using System;
using PPM.Model;
using PPM.Dal;
using System.Xml.Serialization;


namespace PPM.Domain
{
    public class AppDataSerializer
    {
        public static void SerializeData(List<Project> projects, List<Employee> employees, List<Role> roles, List<EmployeeProject> employeeProjects, string projectData, string employeeData, string roleData, string employeeProjectData)
        {

            using (var projectWriter = new StreamWriter(projectData))
            {
                ViewProjectXml();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Project>));
                serializer.Serialize(projectWriter, projects);
            }

            using (var employeeyWriter = new StreamWriter(employeeData))
            {
                ViewEmployeeXml();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                serializer.Serialize(employeeyWriter, employees);
            }
            using (var roleWriter = new StreamWriter(roleData))
            {
                ViewRolesXml();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Role>));
                serializer.Serialize(roleWriter, roles);
            }
           
           
            using (var employeeProjectWriter = new StreamWriter(employeeProjectData))
            {
                 ViewEmployeeProjectXml();
                XmlSerializer serializer = new XmlSerializer(typeof(List<EmployeeProject>));
                serializer.Serialize(employeeProjectWriter, employeeProjects);
            }




        }
        public static void ViewProjectXml()
        {
            ProjectDal.projectList.Clear();
            ProjectRepo projectRepo = new ProjectRepo();
            projectRepo.Get();
        }

        public  static void ViewRolesXml()
        {
            RoleDal.rolesList.Clear();
            RolesRepo rolesRepo = new RolesRepo();
            rolesRepo.Get();
        }
        public static  void ViewEmployeeXml()
        {

            EmployeeDal.employeeList.Clear();
             EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.Get();

        }



           public static void ViewEmployeeProjectXml()
        {
            EmployeeProjectDal.projectEmployeeMember.Clear();
            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
             employeeProjectRepo.GetEmployeeProjects();
        
        }




    }
}