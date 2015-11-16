using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB_MvcApplication4XXL_business_example.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            ViewData["Zemlje"] = new List<string>()
            {
                "India", "Slovenija", "Hrvatska", "Canada", "US"

            };


            return View();
        }

    }
}
