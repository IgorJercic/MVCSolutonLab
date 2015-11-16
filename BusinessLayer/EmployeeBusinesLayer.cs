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


             string connection = "server=.; database=sample2MVC; integrated security=SSPI";

       }



     


       using (SqlConnection con = new SqlConnection(connectionString))
         {

         }



    }
}
