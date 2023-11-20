using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using PPM.Dal;
using PPM.Domain;
using PPM.Model;


namespace PPM.UiConsole
{

    public class EmployeeProjectConsole
    {


        EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
        EmployeeConsole employeeConsole = new EmployeeConsole();
        EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
        EmployeeDal employeeDal = new();

        ProjectDal projectDal = new ProjectDal();

        string projectName;
        int employeeId;
        string employeeFirstName;
        string employeeLastName;
        int roleId;

        public void EmployeeToProject(int projectId)
        {

            int addEmployeeId;

            Project query = projectDal.ViewProjectByIdDal(projectId);

            projectName = query.ProjectName;

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
                        bool employeeExist = employeeDal.EmployeeDalExist(addEmployeeId);
                        if (!employeeExist)
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


                bool employeeProjectExist = employeeProjectDal.CheckEmpProject(projectId, addEmployeeId);
                if (!employeeProjectExist)
                {
                    System.Console.WriteLine("|==Enter employee already added to project==|");
                }
                else
                {
                    Employee query2 = employeeDal.ViewByIdEmployee(addEmployeeId);
                    employeeId = query2.EmployeeId;
                    employeeFirstName = query2.EmployeeFirstName;
                    employeeLastName = query2.EmployeeLastName;
                    roleId = query2.RoleId;
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

            if (!projectDal.ProjectExist())
            {
                System.Console.WriteLine("There are no projects in the list first add projects");
                return;
            }

            if (!employeeDal.EmployeeExist())
            {
                System.Console.WriteLine("|==There are no employees in the list.==|");
                return;
            }
           


            try
            {

                ViewProjectDetails();
                System.Console.Write("\n\n Enter the projectId which you want add employee:");
                int userProjectId = int.Parse(System.Console.ReadLine());

                bool projectExist = projectDal.ProjectDalExist(userProjectId);
                if (projectExist == true)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|==Enter proper projectId==|");
                    return;
                }

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


                bool exist = employeeProjectDal.Exist();
                if (!exist)
                {
                    System.Console.WriteLine("There are no employeproject details in the list");
                    return;
                }

                ViewProjectDetails();
                System.Console.Write("\n\nEnter the projectId from that you want delete employee: ");
                int deleteProjectId = int.Parse(System.Console.ReadLine());

                System.Console.Write("Enter the employeeId which you want delete from project: ");
                int deleteEmployeId = int.Parse(System.Console.ReadLine());



                bool employeeProjectExist = employeeProjectDal.CheckEmpProject(deleteProjectId, deleteEmployeId);
                if (employeeProjectExist)
                {
                    System.Console.WriteLine("No project and employee with the specified ID found.");
                    return;
                }


                employeeProjectRepo.DeleteEmployeeFromProject(deleteProjectId, deleteEmployeId);
                System.Console.WriteLine("Project Deleted Successfully ...");

            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }
        }




        public void ViewProjectDetails()
        {


            EmployeeProjectDal.projectEmployeeMember.Clear();
            bool exist = employeeProjectDal.Exist();
            if (!exist)
            {
                System.Console.WriteLine("There are no employeproject details in the list");
                return;
            }



            var empProjects = employeeProjectRepo.GetEmployeeProjects();
            System.Console.WriteLine("*********************          The Projects With Emloyees Details          ***************************");
            System.Console.WriteLine();

            foreach (var item in empProjects)
            {
                System.Console.WriteLine($"ProjectId : {item.ProjectId}, ProjectName : {item.ProjectName}, EmployeeId: {item.EmployeeId},  EmployeeFirstName : {item.EmployeeFirstName}, EmployeeLastName : {item.EmployeeLastName}, RoleId : {item.RoleId} ");
            }

        }



    }

}
