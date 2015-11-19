using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace BusinessLayer
{
   public class EmployeeBusinesLayer
    {
       //biznis logika koja zadržava sve elemene biznis logike, ovdje imamo samo biznis spajanje s bazom
       //data operations in biznis logic



       public IEnumerable<Employee> Employees
       {

           get{
               List<Employee> emp = new List<Employee>();

             string connection = "server=.; database=sample2MVC; integrated security=SSPI";


                using (SqlConnection con = new SqlConnection(connection))
                  {

                      SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                      cmd.CommandType = CommandType.StoredProcedure;
                      con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Employee emoloyee = new Employee();
                        emoloyee.ID = Convert.ToInt32(rdr["Id"]);
                        emoloyee.Name = rdr["Name"].ToString();
                        emoloyee.Gender = rdr["Gender"].ToString();
                        emoloyee.City = rdr["City"].ToString();
                        if (!(rdr["DateOfBirth"] is DBNull))
                        { 
                        emoloyee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                         }

                        emp.Add(emoloyee);
                    }

                    return emp;
                  }

           }

       }


       public void AddEmployee(Employee employee)
       {
           string connection = "server=.; database=sample2MVC; integrated security=SSPI";

           using(SqlConnection conn = new SqlConnection(connection))
           {


               SqlCommand cmd = new SqlCommand("spAddEmployee", conn);
               cmd.CommandType = CommandType.StoredProcedure;


               SqlParameter paramName = new SqlParameter();
               paramName.ParameterName = "@Name";
               paramName.Value = employee.Name; //mora proči kroz model
               cmd.Parameters.Add(paramName);


               SqlParameter paramGender = new SqlParameter();
               paramGender.ParameterName = "@Gender";
               paramGender.Value = employee.Gender;
               cmd.Parameters.Add(paramGender);


               SqlParameter paramCity = new SqlParameter();
               paramCity.ParameterName = "@City";
               paramCity.Value = employee.City;
               cmd.Parameters.Add(paramCity);


               SqlParameter paramDate = new SqlParameter();
               paramDate.ParameterName = "@DateOfBirth";
               paramDate.Value = employee.DateOfBirth;
               cmd.Parameters.Add(paramDate);

               conn.Open();
               cmd.ExecuteNonQuery();

           }
       }



     


  



    }
}
