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

       //vratit će listu nazad 
       public IEnumerable<Employee> Employeess
       {

           //vrača nam ili ti read only property
           get
           {

               string connection = "server=.; database=sample2MVC; integrated security=SSPI";


               List<Employee> employee = new List<Employee>();

               using (SqlConnection con = new SqlConnection(connection))
               {
                   SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                   cmd.CommandType = CommandType.StoredProcedure;
                   con.Open();
                   SqlDataReader rdr = cmd.ExecuteReader();

                   while(rdr.Read())
                   {
                       Employee empl = new Employee();

                       //prolaz kroz svaki row u tablici i konvertiranje objekta  u employee objekt
                       empl.ID = Convert.ToInt32(rdr["id"]);
                       empl.Name = rdr["Name"].ToString();
                       empl.City = rdr["City"].ToString();
                       empl.Gender = rdr["Gender"].ToString();
                       empl.TimeOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                       employee.Add(empl);

                   }

                   
               }

               return employee;

           }

       }









    }
}
