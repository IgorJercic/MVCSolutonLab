using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public interface IEmployee 
    {

       int ID { get; set; }
       string Gender { get; set; }
       string City { get; set; }
       DateTime? DateOfBirth { get; set; }




    }
}
