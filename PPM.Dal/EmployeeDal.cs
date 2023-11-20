using PPM.Model;

using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PPM.Dal
{

    public class EmployeeDal
    {
        public static List<Employee> employeeList = new List<Employee>();
        string dataBaseConn = "Server = RHJ-9F-D196\\SQLEXPRESS; Database = ProlificsProjectManagment; Integrated Security=SSPI;";


        public void AddEmployeeDal(Employee employee)
        {
            string insertEmployeeQuery = "INSERT INTO Employee(EmployeeId,EmployeeFirstName, EmployeeLastName, Email, MobileNumber, Address, RoleId) VALUES(@EmployeeId, @EmployeeFirstName, @EmployeeLastName,@Email, @MobileNumber, @Address, @RoleId)";
            using (SqlConnection addEmployeeConn = new SqlConnection(dataBaseConn))
            {
                addEmployeeConn.Open();
                using (SqlCommand empInsertCommand = new SqlCommand(insertEmployeeQuery, addEmployeeConn))
                {
                    empInsertCommand.Parameters.AddWithValue("EmployeeId", employee.EmployeeId);
                    empInsertCommand.Parameters.AddWithValue("EmployeeFirstName", employee.EmployeeFirstName);
                    empInsertCommand.Parameters.AddWithValue("EmployeeLastName", employee.EmployeeLastName);
                    empInsertCommand.Parameters.AddWithValue("Email", employee.Email);
                    empInsertCommand.Parameters.AddWithValue("MobileNumber", employee.MobileNumber);
                    empInsertCommand.Parameters.AddWithValue("Address", employee.Address);
                    empInsertCommand.Parameters.AddWithValue("RoleId", employee.RoleId);
                    empInsertCommand.ExecuteNonQuery();

                }
            }
        }

        public List<Employee> GetEmployeeDal()
        {
            string viewEmployeeQuery = "SELECT * FROM Employee";

            using (SqlConnection viewEmployeeConnection = new SqlConnection(dataBaseConn))
            {
                viewEmployeeConnection.Open();

                using (SqlCommand viewEmployeeCommand = new SqlCommand(viewEmployeeQuery, viewEmployeeConnection))
                {
                    using (SqlDataReader viewEmployeeReader = viewEmployeeCommand.ExecuteReader())
                    {
                        while (viewEmployeeReader.Read())
                        {
                            Employee employee = new Employee();

                            employee.EmployeeId = Convert.ToInt32(viewEmployeeReader["EmployeeId"]);
                            employee.EmployeeFirstName = viewEmployeeReader["EmployeeFirstName"].ToString();
                            employee.EmployeeLastName = viewEmployeeReader["EmployeeLastName"].ToString();
                            employee.Email = viewEmployeeReader["EmployeeId"].ToString();
                            employee.MobileNumber = Convert.ToInt64(viewEmployeeReader["MobileNumber"]);
                            employee.RoleId = Convert.ToInt32(viewEmployeeReader["RoleId"]);


                            employeeList.Add(employee);
                        }
                    }
                }
            }

            return employeeList;
        }



        public Employee ViewByIdEmployee(int EmployeeId)
        {
            Employee employee = new();

            string viewEmployeeByIdQuery = $"SELECT * FROM Employee WHERE EmployeeId = '{EmployeeId}';";
            using (SqlConnection viewEmployeeByIdConnection = new SqlConnection(dataBaseConn))
            {
                viewEmployeeByIdConnection.Open();
                using (SqlCommand viewEmployeeByIdCommand = new SqlCommand(viewEmployeeByIdQuery, viewEmployeeByIdConnection))
                {
                    using (SqlDataReader viewEmployeeByIdReader = viewEmployeeByIdCommand.ExecuteReader())
                    {
                        while (viewEmployeeByIdReader.Read())
                        {
                            employee.EmployeeId = Convert.ToInt32(viewEmployeeByIdReader["EmployeeId"]);
                            employee.EmployeeFirstName = viewEmployeeByIdReader["EmployeeFirstName"].ToString();
                            employee.EmployeeLastName = viewEmployeeByIdReader["EmployeeLastName"].ToString();
                            employee.Email = viewEmployeeByIdReader["EmployeeId"].ToString();
                            employee.MobileNumber = Convert.ToInt64(viewEmployeeByIdReader["MobileNumber"]);
                            employee.RoleId = Convert.ToInt32(viewEmployeeByIdReader["RoleId"]);

                        }
                    }
                }
                return employee;
            }


        }


        public void DeleteEmployeetDal(int deleteid)
        {

            string deleteEmployeeQuery = $" DELETE Employee WHERE EmployeeId = '{deleteid}';";

            using (SqlConnection deleteEmployeeConnection = new SqlConnection(dataBaseConn))
            {
                deleteEmployeeConnection.Open();

                using (SqlCommand deleteEmployeecommand = new SqlCommand(deleteEmployeeQuery, deleteEmployeeConnection))
                {
                    deleteEmployeecommand.ExecuteNonQuery();

                }
            }

        }



        public bool EmployeeExist()
        {
            string employeeQuery = "SELECT COUNT(*) FROM Employee";
            using (SqlConnection employeeConn = new SqlConnection(dataBaseConn))
            {
                employeeConn.Open();

                using (SqlCommand employeeCommand = new SqlCommand(employeeQuery, employeeConn))
                {
                    int employeeCount = (int)employeeCommand.ExecuteScalar();
                    return employeeCount > 0;
                }
            }
        }


        public bool EmployeeDalExist(int enteredEmployeeId)
        {


            string employeeExistQuery = $"SELECT COUNT (*) FROM Employee WHERE EmployeeId = '{enteredEmployeeId}'; ";

            using (SqlConnection addEmpConnection = new SqlConnection(dataBaseConn))
            {
                addEmpConnection.Open();

                using (SqlCommand addEmpSqlcommand = new SqlCommand(employeeExistQuery, addEmpConnection))
                {
                    int count = (int)addEmpSqlcommand.ExecuteScalar();

                    if (count != 0)
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



        public bool EmpProjectExist(int employeeIdToDelete)
        {
            string empProQuery = $"SELECT COUNT(*) FROM EmployeeProject WHERE EmployeeId = '{employeeIdToDelete}';";

                using (SqlConnection empProconnection = new SqlConnection(dataBaseConn))
                {
                    empProconnection.Open();

                    using (SqlCommand empProCommand = new SqlCommand(empProQuery, empProconnection))
                    {
                        int empProcount = (int)empProCommand.ExecuteScalar();

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




    }
}