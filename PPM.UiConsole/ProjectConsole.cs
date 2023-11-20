using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using PPM.Dal;
using PPM.Domain;
using PPM.Model;


namespace PPM.UiConsole
{

    public class ProjectConsole
    {

        ProjectRepo projectRepo = new ProjectRepo();
        ProjectDal projectDal = new ProjectDal();
        EmployeeDal employeeDal = new EmployeeDal();



        public int ProjectModule()
        {



            System.Console.WriteLine();




            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("╔════════════════════════════════════════╗");
            System.Console.WriteLine("║          Project Module                ║");
            System.Console.WriteLine("╠════════════════════════════════════════╣");
            System.Console.WriteLine("║ Choose the required option             ║");
            System.Console.WriteLine("║  1. Add Project                        ║");
            System.Console.WriteLine("║  2. View All Projects                  ║");
            System.Console.WriteLine("║  3. View By ProjectId                  ║");
            System.Console.WriteLine("║  4. Delete Project                     ║");
            System.Console.WriteLine("║  5. Add Employee To Project            ║");
            System.Console.WriteLine("║  6. View ProjectEmployee Details       ║");
            System.Console.WriteLine("║  7. Delete Employee From Project       ║");
            System.Console.WriteLine("║  8. Return To Main Menu                ║");
            System.Console.WriteLine("╚════════════════════════════════════════╝");
            System.Console.ResetColor();


            System.Console.Write("Enter your option:");


            int projectOption = 0;
            try
            {

                projectOption = int.Parse(System.Console.ReadLine());
            }
            catch (FormatException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return projectOption;
        }


        public void AddProject()
        {
            int projectId;
            string projectName;
            DateTime startDate;
            DateTime endDate;


            while (true)
            {


                System.Console.WriteLine();

                System.Console.Write("Enter the projectId:");
                if (int.TryParse(System.Console.ReadLine(), out int enteredProjectId))
                {

                    bool exist = projectDal.ProjectDalExist(enteredProjectId);
                    if (!exist)
                    {

                        System.Console.WriteLine("|-- Entered projectId is already there give proper Id --|");
                    }
                    else
                    {
                        projectId = enteredProjectId;
                        break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid input. Please enter a valid integer for the project ID.");
                }

            }

            System.Console.WriteLine();
            System.Console.Write("Enter the projectname: ");
            projectName = System.Console.ReadLine();



            while (true)
            {
                System.Console.WriteLine();
                System.Console.Write("Enter the starting date of project (yyyy-MM-dd): ");
                if (DateTime.TryParse(System.Console.ReadLine(), out startDate))
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|===Invalid date format. Please enter a valid date in yyyy-MM-dd format.==|");

                }
            }



            while (true)
            {
                System.Console.WriteLine();
                while (true)
                {
                    System.Console.WriteLine();
                    System.Console.Write("Enter the end date of project (yyyy-MM-dd): ");
                    if (DateTime.TryParse(System.Console.ReadLine(), out endDate))
                    {
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("|==Invalid date format. Please enter a valid date in yyyy-MM-dd format.==|");
                    }
                }


                if (endDate > startDate)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|==Entered date less than or equal to start date enter proper date==|");

                }

            }
            Project project = new Project()
            {
                ProjectId = projectId,
                ProjectName = projectName,
                StartDate = startDate,
                EndDate = endDate
            };
            projectRepo.Add(project);


            Console.WriteLine("\n\n");

            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Projects added succesfully...        ");
            System.Console.ResetColor();

            System.Console.WriteLine();
            System.Console.Write("Do you want add employee to this project( yes/no):");


            string empToProject = System.Console.ReadLine();

            if (empToProject == "yes" || empToProject == "YES" || empToProject == "Yes")
            {
                if (!employeeDal.EmployeeExist())
                {
                    System.Console.WriteLine("|==There are no employees in the list.==|");
                    return;
                }

                else
                {

                    EmployeeProjectConsole employeeProjectConsole = new EmployeeProjectConsole();
                    employeeProjectConsole.EmployeeToProject(projectId);
                }
            }
            else if (empToProject == "no" || empToProject == "NO" || empToProject == "No")
            {
                return;
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine("|==invalid option==|");
                return;
            }


        }



        public void ViewProject()
        {

            if (!projectDal.ProjectExist())
            {
                System.Console.WriteLine("|==There are no project in the list.==|");
                return;
            }



            ProjectDal.projectList.Clear();
            ProjectRepo projectRepo = new ProjectRepo();

            System.Console.WriteLine("********************* The Project Are ***************************");
            System.Console.WriteLine();

            var projects = projectRepo.Get();

            foreach (var item in projects)
            {
                System.Console.WriteLine($"ProjectId: {item.ProjectId}, ProjectName: {item.ProjectName}, StartDate: {item.StartDate}, EndDate: {item.EndDate}");
            }
        }


        public void ViewByProjectId()
        {

            try
            {


                if (!projectDal.ProjectExist())
                {
                    System.Console.WriteLine("|==There are no project in the list.==|");
                    return;
                }
                System.Console.WriteLine("Enter the projectId ");
                int projetById = int.Parse(System.Console.ReadLine());

                Project project = projectRepo.ViewById(projetById);

                if (project.ProjectId == projetById)
                {

                    System.Console.WriteLine();
                    System.Console.WriteLine($"ProjectId : {project.ProjectId}, ProjectName : {project.ProjectName}, Startsat : {project.StartDate}, EndDate : {project.EndDate}");
                }
                else
                {
                    System.Console.WriteLine("project does not exist");
                }
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }
        }


        public void DeleteProject()
        {

            System.Console.WriteLine();

            if (!projectDal.ProjectExist())
            {
                System.Console.WriteLine("|==There are no project in the list.==|");
                return;
            }
            ViewProject();

          try
          {


            System.Console.WriteLine();
            System.Console.WriteLine("Enter the projectId that you want delete");
            int projectIdToDelete = int.Parse(System.Console.ReadLine());



            bool projectExist = projectDal.ProjectDalExist(projectIdToDelete);
            if (projectExist)
            {
                System.Console.WriteLine("No project with the specified ID found.");
                return;
            }


            bool projectEmployeeExist = projectDal.ProjectEmployeeExist(projectIdToDelete);
            if (!projectEmployeeExist)
            {
                System.Console.WriteLine("This project is on going  ");
            }
            else
            {
                projectRepo.Delete(projectIdToDelete);
                System.Console.WriteLine("Project Deleted Successfully ...");
            }
          }
          catch(Exception exp)
          {
            System.Console.WriteLine(exp.Message);
          }

        }
    }
}






