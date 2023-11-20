using System;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using PPM.Dal;
using PPM.Domain;
using PPM.Model;


namespace PPM.UiConsole
{

    public class RoleConsole
    {




        RoleDal roleDal = new RoleDal();
        RolesRepo rolesRepo = new RolesRepo();
        public int RoleModule()
        {


            // Console.Clear();
            System.Console.WriteLine();

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("╔════════════════════════════════════════╗");
            System.Console.WriteLine("║          Role Module                   ║");
            System.Console.WriteLine("╠════════════════════════════════════════╣");
            System.Console.WriteLine("║ Choose the required option             ║");
            System.Console.WriteLine("║  1. Add Role                           ║");
            System.Console.WriteLine("║  2. View All Roles                     ║");
            System.Console.WriteLine("║  3. View By RoleId                     ║");
            System.Console.WriteLine("║  4. Delete Role                        ║");
            System.Console.WriteLine("║  5. Return To Main Menu                ║");
            System.Console.WriteLine("╚════════════════════════════════════════╝");
            System.Console.ResetColor();


            System.Console.Write("Enter your option:");
            int roleOption = 0;
            try
            {
                roleOption = int.Parse(System.Console.ReadLine());
            }
            catch (FormatException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return roleOption;



        }








        public void AddRole()
        {

            string option;
            do
            {

                int roleId;
                string roleName;



                System.Console.WriteLine();

                while (true)
                {


                    System.Console.WriteLine();

                    System.Console.Write("Enter the RoleId: ");
                    if (int.TryParse(System.Console.ReadLine(), out int enteredRoleId))
                    {

                        bool roleExist = roleDal.RoleDalExist(enteredRoleId);
                        if (!roleExist)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("|==Entered RoleId is already there give proper Id.==|");
                        }
                        else
                        {
                            roleId = enteredRoleId;
                            break;
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("|==Invalid input. Please enter a valid integer for the project ID.==|");
                    }

                }




                System.Console.Write("Enter rolename: ");
                roleName = System.Console.ReadLine();


                Role role = new Role()
                {
                    RoleId = roleId,
                    RoleName = roleName
                };

                rolesRepo.Add(role);


                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine();
                System.Console.WriteLine("Roles added succesfully...        ");
                Console.ResetColor();
                System.Console.Write("Do you want to add another role? (yes/no): ");

                System.Console.ResetColor();
                option = System.Console.ReadLine();
            } while (option == "yes" || option == "Yes" || option == "Yes");

        }



        public void ViewRoles()
        {

            if (!roleDal.RolesExist())
            {
                System.Console.WriteLine("|==There are no roles in the list.==|");
                return;
            }


            RoleDal.rolesList.Clear();
            System.Console.WriteLine("*********************************    The Roles are  listed below   ***********************");
            System.Console.WriteLine();

            var roles = rolesRepo.Get();

            foreach (var item in roles)
            {
                System.Console.WriteLine($"RoleId : {item.RoleId}, RoleName : {item.RoleName}");
            }

        }


        public void ViewRoleById()
        {
            System.Console.WriteLine();

            if (!roleDal.RolesExist())
            {
                System.Console.WriteLine("|==There are no roles in the list.==|");
                return;
            }


            try
            {

                System.Console.Write("Enter the roleId : ");
                int roleById = int.Parse(System.Console.ReadLine());

                Role role = rolesRepo.ViewById(roleById);

                if (role.RoleId == roleById)
                {

                    System.Console.WriteLine();
                    System.Console.WriteLine("The Roles are:");
                    System.Console.WriteLine($"RoleId : {role.RoleId}, RoleName : {role.RoleName}");
                }
                else
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|==role does not exist.==|");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }



        public void DeleteRole()
        {

            if (!roleDal.RolesExist())
            {
                System.Console.WriteLine("|==There are no roles in the list.==|");
                return;
            }

            RoleDal.rolesList.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();

            ViewRoles();
            try
            {

                System.Console.WriteLine();
                System.Console.Write("Enter the roleId that you want delete: ");
                int roleIdToDelete = int.Parse(System.Console.ReadLine());

                bool roleDelete = roleDal.RoleDalExist(roleIdToDelete);

                if (roleDelete)
                {
                    System.Console.WriteLine("No role with the specified ID found.");
                    return;
                }



                bool empRoleExist = roleDal.RoleDelete(roleIdToDelete);

                if (!empRoleExist)
                {
                    System.Console.WriteLine("|==The role is assign to employee.==|");
                    return;
                }
                else
                {
                    rolesRepo.Delete(roleIdToDelete);
                    System.Console.WriteLine("Role Deleted Successfully ...");
                }
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }

        }



    }


}
