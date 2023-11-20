using PPM.Model;

using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PPM.Dal
{

    public class ProjectDal
    {
        public static List<Project> projectList = new List<Project>();
        string connectionString = "Server = RHJ-9F-D196\\SQLEXPRESS; Database = ProlificsProjectManagment; Integrated Security=SSPI;";

        public void AddProjectDal(Project project)
        {
            string insertProjectQuery = $"INSERT INTO Project (ProjectId, ProjectName, StartDate, EndDate) VALUES(@ProjectId, @ProjectName, @StartDate, @EndDate)";
            using (SqlConnection addProjectConn = new SqlConnection(connectionString))
            {
                addProjectConn.Open();

                using (SqlCommand insertCmd = new SqlCommand(insertProjectQuery, addProjectConn))
                {
                    insertCmd.Parameters.AddWithValue("@ProjectId", project.ProjectId);
                    insertCmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    insertCmd.Parameters.AddWithValue("@StartDate", project.StartDate);
                    insertCmd.Parameters.AddWithValue("@EndDate", project.EndDate);

                    insertCmd.ExecuteNonQuery();
                }

            }
        }



        public List<Project> GetProjectsDal()
        {
            string viewAllProjectQuery = $"SELECT * FROM Project";
            using (SqlConnection viewAllProjectconnection = new SqlConnection(connectionString))
            {
                viewAllProjectconnection.Open();

                using (SqlCommand viewAllCmd = new SqlCommand(viewAllProjectQuery, viewAllProjectconnection))
                {
                    using (SqlDataReader viewAllProjectDataReader = viewAllCmd.ExecuteReader())
                    {
                        while (viewAllProjectDataReader.Read())
                        {
                            Project project = new();

                            project.ProjectId = Convert.ToInt32(viewAllProjectDataReader["ProjectId"]);
                            project.ProjectName = viewAllProjectDataReader["ProjectName"].ToString();
                            project.StartDate = Convert.ToDateTime(viewAllProjectDataReader["StartDate"]);
                            project.EndDate = Convert.ToDateTime(viewAllProjectDataReader["EndDate"]);

                            projectList.Add(project);
                        }
                    }


                }
            }

            return projectList;
        }




        public Project ViewProjectByIdDal(int id)
        {
            Project project = new();
            string viewProjectByIdQuery = $"SELECT * FROM Project WHERE ProjectId = '{id}';";
            using (SqlConnection viewProjectByIdconnection = new SqlConnection(connectionString))
            {
                viewProjectByIdconnection.Open();

                using (SqlCommand viewByIdCmd = new SqlCommand(viewProjectByIdQuery, viewProjectByIdconnection))
                {
                    using (SqlDataReader viewProjectcByIdDataReader = viewByIdCmd.ExecuteReader())
                    {
                        while (viewProjectcByIdDataReader.Read())
                        {

                            project.ProjectId = Convert.ToInt32(viewProjectcByIdDataReader["ProjectId"]);
                            project.ProjectName = viewProjectcByIdDataReader["ProjectName"].ToString();
                            project.StartDate = Convert.ToDateTime(viewProjectcByIdDataReader["StartDate"]);
                            project.EndDate = Convert.ToDateTime(viewProjectcByIdDataReader["EndDate"]);

                        }
                    }


                }
                return project;
            }
        }


        public void DeleteProjectDal(int deleteid)
        {

            string deleteQuery = $" DELETE Project WHERE ProjectId = '{deleteid}';";

            using (SqlConnection deleteconnection = new SqlConnection(connectionString))
            {
                deleteconnection.Open();

                using (SqlCommand command = new SqlCommand(deleteQuery, deleteconnection))
                {
                    command.ExecuteNonQuery();

                }
            }

        }



        

        public bool ProjectDalExist(int enteredProjectId)
        {
            string projectExistQuery = $"SELECT COUNT (*) FROM Project WHERE ProjectId = '{enteredProjectId}'; ";

            using (SqlConnection addProConnection = new SqlConnection(connectionString))
            {
                addProConnection.Open();

                using (SqlCommand addProSqlcommand = new SqlCommand(projectExistQuery, addProConnection))
                {
                    int count = (int)addProSqlcommand.ExecuteScalar();

                    if (count != 0)
                    {
                        System.Console.WriteLine();
                        return false; ;
                    }
                    else
                    {
                        return true;

                    }

                }
            }
        }


        public bool ProjectEmployeeExist(int projectIdToDelete)

        {
            string empProQuery = $"SELECT COUNT(*) FROM EmployeeProject WHERE ProjectId = '{projectIdToDelete}';";

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



        public bool ProjectExist()
        {

            string proQuery = $"SELECT COUNT (*) FROM Project";

            using (SqlConnection proConn = new SqlConnection(connectionString))
            {
                proConn.Open();

                using (SqlCommand proCommand = new SqlCommand(proQuery, proConn))
                {
                    int count = (int)proCommand.ExecuteScalar();

                    return count > 0;

                }
            }
        }


        
    }
}