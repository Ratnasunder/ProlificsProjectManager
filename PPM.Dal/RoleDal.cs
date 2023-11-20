using PPM.Model;

using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PPM.Dal
{

    public class RoleDal
    {

        public static List<Role> rolesList = new List<Role>();
        string dataBaseConn = "Server = RHJ-9F-D196\\SQLEXPRESS; Database = ProlificsProjectManagment; Integrated Security=SSPI;";

        public void AddRoleDal(Role role)
        {

            string insertRoleQuery = $"INSERT INTO Role (RoleId, RoleName) VALUES(@RoleId, @RoleName)";
            using (SqlConnection insertRoleConnection = new SqlConnection(dataBaseConn))
            {
                insertRoleConnection.Open();

                using (SqlCommand insertCmd = new SqlCommand(insertRoleQuery, insertRoleConnection))
                {
                    insertCmd.Parameters.AddWithValue("@RoleId", role.RoleId);
                    insertCmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }


        public List<Role> GetRoleDal()
        {

            string viewAllRoleQuery = $"SELECT * FROM Role";
            using (SqlConnection viewAllroleConnection = new SqlConnection(dataBaseConn))
            {
                viewAllroleConnection.Open();

                using (SqlCommand viewAllCmd = new SqlCommand(viewAllRoleQuery, viewAllroleConnection))
                {
                    using (SqlDataReader viewALlroleDataReader = viewAllCmd.ExecuteReader())
                    {
                        while (viewALlroleDataReader.Read())
                        {
                            Role role = new();

                            role.RoleId = Convert.ToInt32(viewALlroleDataReader["RoleId"]);
                            role.RoleName = viewALlroleDataReader["RoleName"].ToString();


                            rolesList.Add(role);
                        }
                    }


                }
            }

            return rolesList;
        }

        public Role ViewRoleByIdDal(int roleId)
        {
            Role role = new();
            string viewRoleByIdQuery = $"SELECT * FROM Role WHERE RoleId = '{roleId}';";
            using (SqlConnection viewRoleByIdconnection = new SqlConnection(dataBaseConn))
            {
                viewRoleByIdconnection.Open();

                using (SqlCommand viewByIdCmd = new SqlCommand(viewRoleByIdQuery, viewRoleByIdconnection))
                {
                    using (SqlDataReader viewRolecByIdDataReader = viewByIdCmd.ExecuteReader())
                    {
                        while (viewRolecByIdDataReader.Read())
                        {

                            role.RoleId = Convert.ToInt32(viewRolecByIdDataReader["RoleId"]);
                            role.RoleName = viewRolecByIdDataReader["RoleName"].ToString();


                        }
                    }


                }
                return role;
            }
        }

        public void DeleteRoleDal(int deleteId)
        {
            string deleteRoleQuery = $" DELETE Role WHERE RoleId = '{deleteId}';";

            using (SqlConnection deleteConnection = new SqlConnection(dataBaseConn))
            {
                deleteConnection.Open();

                using (SqlCommand command = new SqlCommand(deleteRoleQuery, deleteConnection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }




        public bool RoleDalExist(int enteredRoleId)
        {
            string roleExistQuery = $"SELECT COUNT (*) FROM Role WHERE RoleId = '{enteredRoleId}'; ";

            using (SqlConnection addRoleConnection = new SqlConnection(dataBaseConn))
            {
                addRoleConnection.Open();

                using (SqlCommand addRoleSqlcommand = new SqlCommand(roleExistQuery, addRoleConnection))
                {
                    int roleCount = (int)addRoleSqlcommand.ExecuteScalar();

                    if (roleCount != 0)
                    {
                        return false;
                       
                    }
                    else
                    {
                        return true;
                       
                    }

                }
            }

        }

         public bool RolesExist()
        {
            string roleQuery = $"SELECT COUNT (*) FROM Role";
            using (SqlConnection roleConn = new SqlConnection(dataBaseConn))
            {
                roleConn.Open();

                using (SqlCommand roleCommand = new SqlCommand(roleQuery, roleConn))
                {
                    int roleCount = (int)roleCommand.ExecuteScalar();

                    return roleCount > 0;

                }
            }
        }


        public bool RoleDelete(int roleIdToDelete )
        {
             string roleProQuery = $"SELECT COUNT(*) FROM Employee WHERE RoleId = '{roleIdToDelete}';";

            using (SqlConnection roleProconnection = new SqlConnection(dataBaseConn))
            {
                roleProconnection.Open();

                using (SqlCommand roleCommand = new SqlCommand(roleProQuery, roleProconnection))
                {
                    int roleProcount = (int)roleCommand.ExecuteScalar();

                    if (roleProcount != 0)
                    {
                        
                        return false;
                    }
                    else
                    {
                        return true;
                        
                    }

                }
            }

        }

    }
}