using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using PPM.Dal;
using PPM.Domain;
using PPM.Model;
using System.Reflection.Metadata;


namespace PPM.UiConsole
{

    public class EmployeeConsole
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        RoleConsole roleConsole = new RoleConsole();
        RoleDal roleDal = new RoleDal();
        EmployeeDal employeeDal = new EmployeeDal();
       




        public int EmployeeModule()
        {


            //  Console.Clear();
            System.Console.WriteLine();

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("╔════════════════════════════════════════╗");
            System.Console.WriteLine("║          Employee Module               ║");
            System.Console.WriteLine("╠════════════════════════════════════════╣");
            System.Console.WriteLine("║ Choose the required option             ║");
            System.Console.WriteLine("║  1. Add Employee                       ║");
            System.Console.WriteLine("║  2. View All Employees                 ║");
            System.Console.WriteLine("║  3. View By EmployeeId                 ║");
            System.Console.WriteLine("║  4. Delete Employee                    ║");
            System.Console.WriteLine("║  5. Return To Main Menu                ║");
            System.Console.WriteLine("╚════════════════════════════════════════╝");
            System.Console.ResetColor();


            System.Console.Write("Enter your option:");
            int employeeOption = 0;
            try
            {

                employeeOption = int.Parse(System.Console.ReadLine());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return employeeOption;
        }





        public void AddEmployee()
        {

            string select;
            do
            {

                int employeeId;
                string employeeFirstName;
                string employeeLastName;
                string email;
                long mobileNumber;
                string address;
                int roleId;


                if (!roleDal.RolesExist())
                {
                    System.Console.WriteLine("|==There are no roles in the list.==|");
                    return;
                }

                while (true)
                {


                    System.Console.WriteLine();
                    System.Console.Write("Enter the EmployeeId: ");


                    if (int.TryParse(System.Console.ReadLine(), out int enteredEmployeeId))
                    {
                        bool empExist = employeeDal.EmployeeDalExist(enteredEmployeeId);

                        if (!empExist)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("|==Entered EmployeeId is already there give proper Id.==|");
                        }
                        else
                        {
                            employeeId = enteredEmployeeId;
                            break;
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("|==Invalid input. Please enter a valid integer for the project ID.==|");
                    }

                }
                System.Console.WriteLine();
                System.Console.Write("Enter the  employee firstname: ");
                employeeFirstName = System.Console.ReadLine();

                System.Console.WriteLine();
                System.Console.Write("Enter the employee lastname: ");
                employeeLastName = System.Console.ReadLine();


                while (true)
                {
                    Console.WriteLine();
                    Console.Write("Enter the employee email: ");
                    email = Console.ReadLine();

                    string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                    if (Regex.IsMatch(email, emailPattern))
                    {

                        if (!email.EndsWith(".com") && !email.EndsWith(".org") && !email.EndsWith(".net"))
                        {
                            Console.WriteLine();
                            Console.WriteLine("|==Enter a valid email address with a common domain extension.==|");
                        }
                        else if (email.Contains(".."))
                        {
                            Console.WriteLine();
                            Console.WriteLine("|==Enter a valid email address without consecutive dots.==|");
                        }
                        else if (email.Contains(" "))
                        {
                            Console.WriteLine();
                            Console.WriteLine("|==Enter a valid email address without spaces.==|");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("|==Enter a valid email address.==|");
                    }
                }


                while (true)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter the employee mobile number in the format +91XXXXXXXXXX (13 characters).");
                    string enteredMobileNumber = System.Console.ReadLine();

                    if (enteredMobileNumber.Length == 13 && enteredMobileNumber.StartsWith("+91") && long.TryParse(enteredMobileNumber.Substring(3), out long Mobile))
                    {
                        mobileNumber = Mobile;
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("|==Enter a proper mobile numbeer.==|");
                    }
                }

                System.Console.WriteLine();
                System.Console.Write("Enter the  employee address: ");
                address = System.Console.ReadLine();


                while (true)
                {

                    try
                    {


                        System.Console.WriteLine();
                        System.Console.Write("Enter the  employee roleId: ");
                        roleId = int.Parse(System.Console.ReadLine());

                        RolesRepo rolesRepo = new RolesRepo();
                        var roleExist = rolesRepo.ViewById(roleId);

                        if (roleExist.RoleId != roleId)
                        {
                            System.Console.WriteLine("|==Entered RoleId is not found  give proper Id==|");


                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception exp)
                    {
                        System.Console.WriteLine(exp.Message);
                    }

                }
                System.Console.ResetColor();


                Employee employee = new Employee()
                {
                    EmployeeId = employeeId,
                    EmployeeFirstName = employeeFirstName,
                    EmployeeLastName = employeeLastName,
                    Email = email,
                    MobileNumber = mobileNumber,
                    Address = address,
                    RoleId = roleId

                };

                employeeRepo.Add(employee);




                Console.WriteLine("\n\n");

                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Employees added succesfully...        ");
                System.Console.ResetColor();

                System.Console.Write("Do you want to add another employee? (yes/no): ");

                select = System.Console.ReadLine();
            } while (select == "yes" || select == "Yes" || select == "Yes");

        }


        public void ViewEmployee()
        {
            if (!employeeDal.EmployeeExist())
            {
                System.Console.WriteLine("|==There are no employees in the list.==|");
                return;
            }


            EmployeeDal.employeeList.Clear();

            System.Console.WriteLine("*********************************             The Employees are  listed below                ***********************");
            System.Console.WriteLine();


            var employee = employeeRepo.Get();
            foreach (var item in employee)
            {
                System.Console.WriteLine($"EmployeeId: {item.EmployeeId}, EmployeeFirstName: {item.EmployeeFirstName}, EmployeeLastName {item.EmployeeLastName}, Email: {item.Email}, MobileNumber: {item.MobileNumber}, Address: {item.Address}, RoleId:{item.RoleId}");
            }


        }

        public void ViewEmployeeById()
        {

            if (!employeeDal.EmployeeExist())
            {
                System.Console.WriteLine("|==There are no employees in the list.==|");
                return;
            }
            try
            {

                System.Console.WriteLine("Enter the employeeId: ");
                int employeeById = int.Parse(System.Console.ReadLine());

                Employee employee = employeeRepo.ViewById(employeeById);

                if (employee.EmployeeId == employeeById)
                {

                    System.Console.WriteLine();
                    System.Console.WriteLine("The Employees are:");
                    System.Console.WriteLine($"EmployeeId :{employee.EmployeeId}, EmployeeFirstName : {employee.EmployeeFirstName}, EmployeeLastName : {employee.EmployeeLastName}, Email : {employee.Email},  MobileNumber : {employee.MobileNumber}, Address : {employee.Address}, RoleId:{employee.RoleId}");
                }
                else
                {
                    System.Console.WriteLine("|==project does not exist.==|");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        public void DeleteEmployee()
        {


            if (!employeeDal.EmployeeExist())
            {
                System.Console.WriteLine("|==There are no employees in the list.==|");
                return;
            }

            ViewEmployee();


            try
            {

                System.Console.WriteLine();
                System.Console.Write("Enter the employeeId that you want delete: ");
                int employeeIdToDelete = int.Parse(System.Console.ReadLine());

                bool deleteEmployeeExist = employeeDal.EmployeeDalExist(employeeIdToDelete);

                if (deleteEmployeeExist)
                {
                    System.Console.WriteLine("No employee with the specified ID found.");
                    return;

                }
                

                bool empProjectExist = employeeDal.EmpProjectExist(employeeIdToDelete);

                if (!empProjectExist)
                {
                    System.Console.WriteLine("|==The employee is assign to project.==|");
                }
                else
                {
                    employeeRepo.Delete(employeeIdToDelete);
                    System.Console.WriteLine("Employee Deleted Successfully ...");
                }

            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }

        }





    }

}