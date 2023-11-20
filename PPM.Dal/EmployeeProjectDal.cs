using PPM.Model;

using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PPM.Dal
{
    public class EmployeeProjectDal
    {

        string connectionString = "Server = RHJ-9F-D196\\SQLEXPRESS; Database = ProlificsProjectManagment; Integrated Security=SSPI;";
         public static List<EmployeeProject> projectEmployeeMember = new List<EmployeeProject>();
        string? projectName;


        public void AddEmployeeProjectDal(EmployeeProject employeeProject)
        {

            string insertEmployeeProjectQuery = $"INSERT INTO EmployeeProject (ProjectId, ProjectName, EmployeeId, EmployeeFirstName,EmployeeLastName, RoleId) VALUES(@ProjectId, @ProjectName, @EmployeeId, @EmployeeFirstName,@EmployeeLastName,@RoleId)";
            using (SqlConnection addEmployeeProjectConn = new SqlConnection(connectionString))
            {
                addEmployeeProjectConn.Open();

                using (SqlCommand insertCmd = new SqlCommand(insertEmployeeProjectQuery, addEmployeeProjectConn))
                {
                    insertCmd.Parameters.AddWithValue("@ProjectId", employeeProject.ProjectId);
                    insertCmd.Parameters.AddWithValue("@ProjectName", employeeProject.ProjectName);
                    insertCmd.Parameters.AddWithValue("@EmployeeId", employeeProject.EmployeeId);
                    insertCmd.Parameters.AddWithValue("@EmployeeFirstName", employeeProject.EmployeeFirstName);
                    insertCmd.Parameters.AddWithValue("@EmployeeLastName", employeeProject.EmployeeLastName);
                    insertCmd.Parameters.AddWithValue("@RoleId", employeeProject.RoleId);

                    insertCmd.ExecuteNonQuery();
                }

            }
        }

        public List<EmployeeProject> GetEmployeeProjectsDal()
        {
            string viewAllEmployeeProjectQuery = $"SELECT * FROM EmployeeProject";
            using (SqlConnection viewAllEmployeeProjectconnection = new SqlConnection(connectionString))
            {
                viewAllEmployeeProjectconnection.Open();

                using (SqlCommand viewAllCmd = new SqlCommand(viewAllEmployeeProjectQuery, viewAllEmployeeProjectconnection))
                {
                    using (SqlDataReader viewAllEmployeeProjectDataReader = viewAllCmd.ExecuteReader())
                    {
                        while (viewAllEmployeeProjectDataReader.Read())
                        {
                            EmployeeProject employeeProject = new();

                            employeeProject.ProjectId = Convert.ToInt32(viewAllEmployeeProjectDataReader["ProjectId"]);
                            employeeProject.ProjectName = viewAllEmployeeProjectDataReader["ProjectName"].ToString();
                            employeeProject.EmployeeId = Convert.ToInt32(viewAllEmployeeProjectDataReader["EmployeeId"]);
                            employeeProject.EmployeeFirstName = viewAllEmployeeProjectDataReader["EmployeeFirstName"].ToString();
                            employeeProject.EmployeeLastName = viewAllEmployeeProjectDataReader["EmployeeLastName"].ToString();
                            employeeProject.RoleId = Convert.ToInt32(viewAllEmployeeProjectDataReader["RoleId"]);
                            
                            projectEmployeeMember.Add(employeeProject);
                        }
                    }


                }
            }

            return projectEmployeeMember;
        }

         public void DeleteEmployeeProjectDal(int deleteProjectId, int deleteEmployeId )
        {

            string deleteEmpProQuery = $" DELETE EmployeeProject WHERE ProjectId = '{deleteProjectId}' and EmployeeId = '{deleteEmployeId}';";

            using (SqlConnection deleteEmpProconnection = new SqlConnection(connectionString))
            {
                deleteEmpProconnection.Open();

                using (SqlCommand empProcommand = new SqlCommand(deleteEmpProQuery, deleteEmpProconnection))
                {
                    empProcommand.ExecuteNonQuery();

                }
            }

        }


        public bool CheckEmpProject(int projectIdToDelete, int employeeId)

        {
            string empProQuery = $"SELECT COUNT(*) FROM EmployeeProject WHERE ProjectId = '{projectIdToDelete}' and EmployeeId = '{employeeId}';";

            using (SqlConnection empProconnection = new SqlConnection(connectionString))
            {
                empProconnection.Open();

                using (SqlCommand command = new SqlCommand(empProQuery, empProconnection))
                {
                    int empProcount = (int)command.ExecuteScalar();

                    if (empProcount != 0)
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



        public bool Exist()
        {
            string empProQuery = $"SELECT COUNT (*) FROM EmployeeProject";
            using (SqlConnection empProConn = new SqlConnection(connectionString))
            {
                empProConn.Open();

                using (SqlCommand empProCommand = new SqlCommand(empProQuery, empProConn))
                {
                    int count = (int)empProCommand.ExecuteScalar();

                    return count > 0;

                }
            }
        }




    }
}
