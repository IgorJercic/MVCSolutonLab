using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace LAB_MvcApplication4XXL_business_example.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            EmployeeBusinesLayer emps = new EmployeeBusinesLayer();
            List<Employee> employee = emps.Employees.ToList();


            return View(employee);
        }





        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            //odogovara na zahtjev od create iz index ovog kontrolera 
            return View();
        }






        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            
            //Model Binders

            if(ModelState.IsValid)
            //ako je model prošao validaciju ako to samo ako je u View @Html.ValidationSummary(true)
            {
                Employee employee = new Employee(); //sva propery su null u ovom trenutkku
                UpdateModel(employee); //no sada sve što je stavljeno u formu će se bindat s view formom
                EmployeeBusinesLayer EmployeBuss = new EmployeeBusinesLayer();
                EmployeBuss.AddEmployee(employee);

                return RedirectToAction("Index");
            }

            ViewBag.greska = "Nisi dobro ispunio obrazac";
            return View();
  


        }








        [HttpGet]
       
        public ActionResult Edit(int id)
        {
            EmployeeBusinesLayer emplY = new EmployeeBusinesLayer();
            Employee employeer = emplY.Employees.Single(ep => ep.ID == id);
            return View(employeer);
        }







        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinesLayer emp = new EmployeeBusinesLayer();
            Employee employee = emp.Employees.Single(x => x.ID == id);
            UpdateModel<IEmployee>(employee); //na ovaj način ćemo update samo ono što je u interface


            if (ModelState.IsValid)
            {

                emp.SaveEmployee(employee);
                return RedirectToAction("Index");
            }


            return View(employee);
        }







        #region koristeći samo model
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)
        //{
        //    EmployeeBusinesLayer emp = new EmployeeBusinesLayer();
        //    Employee employee = emp.Employees.Single(x => x.ID == id);
        //    UpdateModel(employee, new string[] { "ID", "Gender", "City", "DateOfBirth" });


        //    if (ModelState.IsValid)
        //    {
               
        //        emp.SaveEmployee(employee);
        //        return RedirectToAction("Index");
        //    }


        //    return View(employee);
        //}

        #endregion






        #region zbog ovog zapisa se kroz fiddler može hackat aplikacija, jednostavno jer se cjeli objekt Employee kroz klasu mora update i to putem forme (model binding), sve što prolazi kroz post na server će se spremit na server
        //[HttpPost]
        //public ActionResult Edit(Employee employee)
        //{
           

        //      if(ModelState.IsValid)
        //      {
        //          EmployeeBusinesLayer emp = new EmployeeBusinesLayer();
        //          emp.SaveEmployee(employee);
        //          return RedirectToAction("Index");
        //      }

           
        //      return View(employee);
        //}

        #endregion



        //koristi malo jednostavniji model binding

        //[HttpPost]
        // public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth)
        //{
        //    //formCollection objekt iz View, on vrača Value = Key  svojstva
        //    //odogovara s skupljenim podacima iz forme na post iz create view ovog kontrolera 
        //    //Model Binders

        //    Employee emp = new Employee();
        //    emp.Name = name;
        //    emp.Gender = gender;
        //    emp.City = city;
        //    emp.DateOfBirth = dateOfBirth;

        //    EmployeeBusinesLayer emps = new EmployeeBusinesLayer();
        //    emps.AddEmployee(emp);


        //    return RedirectToAction("Index");



        //}





        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinesLayer employ = new EmployeeBusinesLayer();
            employ.DeleteEmployee(id);
            return RedirectToAction("Index");
        }









        //korsisti formCollection
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    //formCollection objekt iz View, on vrača Value = Key  svojstva
        //    //odogovara s skupljenim podacima iz forme na post iz create view ovog kontrolera 
        //    //Model Binders

        //    Employee emp = new Employee();
        //    emp.Name = formCollection["Name"];
        //    emp.Gender = formCollection["Gender"];
        //    emp.City = formCollection["City"];
        //    emp.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);


        //    EmployeeBusinesLayer emps = new EmployeeBusinesLayer();
        //    emps.AddEmployee(emp);


        //    return RedirectToAction("Index");



        //}




    }
}
