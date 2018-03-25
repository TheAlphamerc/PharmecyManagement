using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PharmAssistent.Models;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PharmAssistent.Models
{


    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
                List<Employee> employees = new List<Employee>();
                List<Emp> emps = new List<Emp>();

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployeeData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.City = rdr["City"].ToString();
                        employee.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                        employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Name = rdr["Name"].ToString();
                        employee.DepartmentName = rdr["DepartmentName"].ToString();
                        employees.Add(employee);

                    }

                }
                return employees;
            }

        }



        public List<Employee> SingleEmployee(int Id)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
            List<Employee> employees = new List<Employee>();
            List<Emp> emps = new List<Emp>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select EmpId,Name,Gender,City,DepartmentName,DepartmentId from spSingleEmployeeView where EmpId = @Id ", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.City = rdr["City"].ToString();
                    employee.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                    employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Name = rdr["Name"].ToString();
                    employee.DepartmentName = rdr["DepartmentName"].ToString();
                    employees.Add(employee);

                }
                return employees;

            }
        }

        public void AddEmployee(Employee employee)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                // SqlCommand cmd = new SqlCommand("insert into tblEmployee (EmpId,Name,Gender,City,DepartmentId) values (@EmpId,@Name,@Gender,@City,@DepartmentId)", con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramEmpId = new SqlParameter();
                paramEmpId.ParameterName = "@EmpId ";
                paramEmpId.Value = employee.EmpId;
                cmd.Parameters.Add(paramEmpId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDepartmentId = new SqlParameter();
                paramDepartmentId.ParameterName = "@DepartmentId";
                paramDepartmentId.Value = employee.DepartmentId;
                cmd.Parameters.Add(paramDepartmentId);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        // Registration For Login Class


        //        public  List<LoginClass>  TryLogin(LoginClass login)
        //        {
        //            List<LoginClass> Login = new List<LoginClass>();

        //            string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
        //            using (SqlConnection con = new SqlConnection(ConnectionString))
        //            {
        //                //SqlCommand cmd = new SqlCommand("Select * from LoginTable where Email = '@Email' AND Pass_word = '@Pass_word'", con);
        //                SqlCommand cmd = new SqlCommand("spTryLogin", con);
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter paramEmail = new SqlParameter();
        //                paramEmail.ParameterName = "@Email";
        //                paramEmail.Value = login.Email;
        //                cmd.Parameters.Add(paramEmail);

        //                SqlParameter paramPass_word = new SqlParameter();
        //                paramPass_word.ParameterName = "@Pass_word";
        //                paramPass_word.Value = login.Pass_word;
        //                cmd.Parameters.Add(paramPass_word);

        //                con.Open();
        //                SqlDataReader rdr = cmd.ExecuteReader();

        //                if(rdr!= null)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        LoginClass log = new LoginClass();
        //                        log.Address = rdr["Address"].ToString();
        //                        log.City = rdr["City"].ToString();
        //                        log.ZipCode = Convert.ToInt32(rdr["ZipCode"]);
        //                        log.Country = rdr["Country"].ToString();
        //                        log.Email = rdr["Email"].ToString();
        //                        log.Estate = rdr["Estate"].ToString();
        //                        log.Location = rdr["Location"].ToString();
        //                        log.OrganisationName = rdr["OrganisationName"].ToString();
        //                        log.Pass_word = rdr["Pass_word"].ToString();
        //                        Login.Add(login);

        //                    }

        //                }

        //                return (Login);
        //        }
        //}


        public void DeleteEmployee(int Id)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //   SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id ";
                paramId.Value = Id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void SaveEmployee(Employee employee)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramEmpId = new SqlParameter();
                paramEmpId.ParameterName = "@EmpId ";
                paramEmpId.Value = employee.EmpId;
                cmd.Parameters.Add(paramEmpId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDepartmentId = new SqlParameter();
                paramDepartmentId.ParameterName = "@DepartmentId";
                paramDepartmentId.Value = employee.DepartmentId;
                cmd.Parameters.Add(paramDepartmentId);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }



    }
}
