using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using PPM.Domain;


namespace PPM.UiConsole
{

    public class EmployeeProjectConsole
    {

        ProjectRepo projectRepo = new ProjectRepo();
        EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
        EmployeeConsole employeeConsole = new EmployeeConsole();
        ProjectConsole projectConsole = new ProjectConsole();
       
        string projectName;
        int employeeId;
        string employeeFirstName;
        string employeeLastName;
        int roleId;

        public void EmployeeToProject(int projectId)
        {

            int addEmployeeId;

            bool projectExist = ProjectRepo.projectList.Any(p => p.ProjectId == projectId);
            if (!projectExist)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("|==Enter proper projectId==|");
                return;
            }


            var query1 = from item in ProjectRepo.projectList
                         where item.ProjectId == projectId
                         select new { item.ProjectName };

            foreach (var item in query1)
            {
                projectName = item.ProjectName;
            }


            employeeConsole.ViewEmployee();//for showing employee list         
            while (true)
            {
                while (true)
                {
                    try
                    {

                        System.Console.WriteLine();
                        System.Console.Write("Enter the employee id that you want add Project:");
                        addEmployeeId = int.Parse(System.Console.ReadLine());
                        if (addEmployeeId == 0)
                        {
                            return;
                        }
                        bool employeeExist = EmployeeRepo.employeeList.Any(p => p.EmployeeId == addEmployeeId);
                        if (employeeExist)
                        {
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("|==Enter Proper Id==|");
                        }
                    }
                    catch (Exception exp)
                    {
                        System.Console.WriteLine(exp.Message);
                    }

                }


                bool employeeProjectExist = EmployeeProjectRepo.projectEmployeeMember.Any(p => p.ProjectId == projectId && p.EmployeeId == addEmployeeId);
                if (employeeProjectExist)
                {
                    System.Console.WriteLine("|==Enter employee already added to project==|");
                }
                else
                {
                    var query2 = from items in EmployeeRepo.employeeList
                                 where items.EmployeeId == addEmployeeId
                                 select new { items.EmployeeId, items.EmployeeFirstName, items.EmployeeLastName, items.RoleId };

                    foreach (var item in query2)
                    {
                        employeeId = item.EmployeeId;
                        employeeFirstName = item.EmployeeFirstName;
                        employeeLastName = item.EmployeeLastName;
                        roleId = item.RoleId;
                    }
                    break;
                }
            }

            employeeProjectRepo.EmployeeToProject(projectId, projectName, employeeId, employeeFirstName, employeeLastName, roleId);



            Console.WriteLine("\n\n");

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Employee added to porject....       ");
            System.Console.ResetColor();
        }

        public void AddEmployeeToProject()
        {


             if (ProjectRepo.projectList.Count == 0)
            {
                System.Console.WriteLine("There are no projects in the list first add projects");
                return;
            } 

           
           
            try
            {

                System.Console.Write("Enter the projectId which you want add employee:");
                int userProjectId = int.Parse(System.Console.ReadLine());
                EmployeeProjectConsole employeeProject = new EmployeeProjectConsole();
                employeeProject.EmployeeToProject(userProjectId);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }
        }



        public void DeleteEmployeeFromProject()
        {
            try
            {

                System.Console.Write("Enter the projectId from that you want delete employee: ");
                int deleteProjectId = int.Parse(System.Console.ReadLine());

                System.Console.Write("Enter the employeeId which you want delete from project: ");
                int deleteEmployeId = int.Parse(System.Console.ReadLine());

                bool employeeDeleted;
                employeeProjectRepo.DeleteEmployeeFromProject(deleteProjectId, deleteEmployeId, out employeeDeleted);

                if (employeeDeleted)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("|==Employee removed from the project.==|");
                    Console.ResetColor();
                }
                else
                {
                    System.Console.WriteLine("|==Employee or Project not found.==|");
                }
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }
        }




        public void ViewProjectDetails()
        {
            System.Console.WriteLine("*********************          The Projects With Emloyees Details          ***************************");
            System.Console.WriteLine();

            foreach (var item in EmployeeProjectRepo.projectEmployeeMember)
            {
                System.Console.WriteLine($"ProjectId : {item.ProjectId}, ProjectName : {item.ProjectName}, EmployeeId: {item.EmployeeId},  EmployeeFirstName : {item.EmployeeFirstName}, EmployeeLastName : {item.EmployeeLastName}, RoleId : {item.RoleId} ");
            }

        }



    }

}
