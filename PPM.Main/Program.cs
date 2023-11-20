using PPM.UiConsole;
using PPM.Domain;
namespace PPM.Main
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {

            Console.Clear();
            EmployeeProjectConsole empProjectObject = new EmployeeProjectConsole();
            ProjectConsole projectConsole = new ProjectConsole();
            ProjectRepo projectRepo = new ProjectRepo();
            EmployeeConsole employeeConsole = new EmployeeConsole();
            RoleConsole roleConsole = new RoleConsole();
            ConsoleUI consoleUI = new ConsoleUI();



            int switchChoice;
            int projectChoice;
            int employeeChoice;
            int roleChoice;
            bool returnToMainMenu;
            do
            {
                returnToMainMenu = false;

                switchChoice = consoleUI.Menu();
                switch (switchChoice)
                {
                    case 1:

                        do
                        {

                            projectChoice = projectConsole.ProjectModule();
                            switch (projectChoice)
                            {
                                case 1:
                                    projectConsole.AddProject();
                                    break;
                                case 2:
                                    projectConsole.ViewProject();
                                    break;
                                case 3:
                                    projectConsole.ViewByProjectId();
                                    break;
                                case 4:
                                    projectConsole.DeleteProject();
                                    break;

                                case 5:

                                    empProjectObject.AddEmployeeToProject();

                                    break;
                                case 6:
                                    empProjectObject.ViewProjectDetails();

                                    break;

                                case 7:
                                    empProjectObject.DeleteEmployeeFromProject();

                                    break;
                                case 8:
                                    returnToMainMenu = true; // Set the flag to return to the main menu
                                    break;
                                default:
                                    consoleUI.Invalid();
                                    break;

                            }
                        } while (!returnToMainMenu);

                        break;


                    case 2:
                        do
                        {
                            roleChoice = roleConsole.RoleModule();
                            switch (roleChoice)
                            {
                                case 1:
                                    roleConsole.AddRole();
                                    break;
                                case 2:
                                    roleConsole.ViewRoles();
                                    break;
                                case 3:
                                    roleConsole.ViewRoleById();
                                    break;
                                case 4:
                                    roleConsole.DeleteRole();
                                    break;
                                case 5:
                                    returnToMainMenu = true; // Set the flag to return to the main menu
                                    break;
                                default:
                                    consoleUI.Invalid();
                                    break;

                            }
                        } while (!returnToMainMenu);
                        break;
                    case 3:


                        do
                        {

                            employeeChoice = employeeConsole.EmployeeModule();
                            switch (employeeChoice)
                            {
                                case 1:
                                    employeeConsole.AddEmployee();
                                    break;
                                case 2:
                                    employeeConsole.ViewEmployee();
                                    break;
                                case 3:
                                    employeeConsole.ViewEmployeeById();
                                    break;
                                case 4:
                                    employeeConsole.DeleteEmployee();
                                    break;
                                case 5:
                                    returnToMainMenu = true; // Set the flag to return to the main menu
                                    break;
                                default:
                                    consoleUI.Invalid();
                                    break;

                            }
                        } while (!returnToMainMenu);
                        break;


                    case 4:
                        consoleUI.SaveAppData();
                        break;


                    case 5:
                        consoleUI.Exit();
                        break;
                    default:
                        consoleUI.Invalid();

                        break;

                }
                // ConsoleUI.Continue(); 

            } while (switchChoice != 5);
        }
    }
}



















