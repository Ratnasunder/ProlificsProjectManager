using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using PPM.Dal;
using PPM.Domain;


namespace PPM.UiConsole
{


    public class ConsoleUI
    {

        public int Menu()
        {

          
           
            System.Console.WriteLine();




            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("╔════════════════════════════════════════╗");
            System.Console.WriteLine("║Welcome To ProlificsProjectManagementApp║");
            System.Console.WriteLine("╠════════════════════════════════════════╣");
            System.Console.WriteLine("║ Choose the required option             ║");
            System.Console.WriteLine("║  1. Project Module                     ║");
            System.Console.WriteLine("║  2. Role Module                        ║");
            System.Console.WriteLine("║  3. Employee Module                    ║");
            System.Console.WriteLine("║  4. Save                               ║");
            System.Console.WriteLine("║  5. Quit                               ║");
            System.Console.WriteLine("╚════════════════════════════════════════╝");
            System.Console.ResetColor();

            System.Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.Write("Enter your option:");
            Console.ResetColor();
            int selectedOption = 0;
            try
            {

                selectedOption = int.Parse(System.Console.ReadLine());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return selectedOption;


        }


        public void Exit()
        {
            System.Console.WriteLine("Exiting Application......");
        }

        public void Invalid()
        {
            System.Console.WriteLine("Please give valid input");
        }


        public void Continue()
        {
            System.Console.WriteLine("\n\n");
            System.Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void SaveAppData()
        {
            string projectPath = "C:\\Users\\RaDasari\\Desktop\\ProlificsProjectManager\\PPM.Xml\\ProjectData.xml";
            string employeePath = "C:\\Users\\RaDasari\\Desktop\\ProlificsProjectManager\\PPM.Xml\\EmployeeData.xml";
            string rolePath = "C:\\Users\\RaDasari\\Desktop\\ProlificsProjectManager\\PPM.Xml\\RoleData.xml";
            string employeeProjectPath = "C:\\Users\\RaDasari\\Desktop\\ProlificsProjectManager\\PPM.Xml\\EmployeeProjectData.xml";

            AppDataSerializer.SerializeData(ProjectDal.projectList, EmployeeDal.employeeList, RoleDal.rolesList, EmployeeProjectDal.projectEmployeeMember, projectPath, employeePath, rolePath, employeeProjectPath);
            Console.WriteLine("Application data saved successfully.");
        }
    }
}
