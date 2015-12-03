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


       public void SaveEmployee(Employee employee)
       {

           string connection = "server=.; database=sample2MVC; integrated security=SSPI";

           using (SqlConnection conn = new SqlConnection(connection))
           {

               SqlCommand com = new SqlCommand("spSaveEmployee", conn);
               com.CommandType = CommandType.StoredProcedure;

               SqlParameter idEmp = new SqlParameter();
               idEmp.ParameterName = "@Id";
               idEmp.Value = employee.ID;
               com.Parameters.Add(idEmp);

               SqlParameter Name = new SqlParameter();
               Name.ParameterName = "@Name";
               Name.Value = employee.Name;
               com.Parameters.Add(Name);

               SqlParameter Gender = new SqlParameter();
               Gender.ParameterName = "@Gender";
               Gender.Value = employee.Gender;
               com.Parameters.Add(Gender);


               SqlParameter DateBirth = new SqlParameter();
               DateBirth.ParameterName = "@DateOfBirth";
               DateBirth.Value = employee.DateOfBirth;
               com.Parameters.Add(DateBirth);


               SqlParameter CityP = new SqlParameter();
               CityP.ParameterName = "@City";
               CityP.Value = employee.City;
               com.Parameters.Add(CityP);

               conn.Open();
               com.ExecuteNonQuery();



           }




       }


          public void DeleteEmployee(int id)
         {
             string connection = "server=.; database=sample2MVC; integrated security=SSPI";

              using (SqlConnection conn = new SqlConnection(connection))
              {
                  SqlCommand cmd = new SqlCommand("spDeleteEmployee", conn);
                  cmd.CommandType = CommandType.StoredProcedure;

                  SqlParameter paramID = new SqlParameter();
                  paramID.ParameterName = "@Id";
                  paramID.Value = id;
                  cmd.Parameters.Add(paramID);

                  conn.Open();
                  cmd.ExecuteNonQuery();
              }






         }
  



    }
}
