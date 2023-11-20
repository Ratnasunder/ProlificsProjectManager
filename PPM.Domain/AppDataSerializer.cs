using System;
using PPM.Model;

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PPM.Domain
{
    public class AppDataSerializer
    {
        public static void SerializeData(List<Project> projects, List<Employee> employees, List<Role> roles, List<EmployeeProject> employeeProjects, string projectData, string employeeData, string roleData, string employeeProjectData)
        {

            using (var projectWriter = new StreamWriter(projectData))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Project>));
                serializer.Serialize(projectWriter, projects);
            }

            using (var employeeyWriter = new StreamWriter(employeeData))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                serializer.Serialize(employeeyWriter, employees);
            }
            using (var roleWriter = new StreamWriter(roleData))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Role>));
                serializer.Serialize(roleWriter, roles);
            }
            using (var employeeProjectWriter = new StreamWriter(employeeProjectData))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<EmployeeProject>));
                serializer.Serialize(employeeProjectWriter, employeeProjects);
            }



        }
    }
}