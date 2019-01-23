using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class LoginController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Login
        public ActionResult Index()
        {
            var viewModel = new LoginIndexData();
            
            //Select instructors and students, separate them into two
            viewModel.Instructors = db.Instructors;
            viewModel.Students = db.Students;

            //Select from Person then split sort by discriminator (testing)
            //viewModel.Instructors = db.People.OfType<Student>;
            //viewModel.Students = db.People.OfType<Instructor>;

            //To Test, Querying from the single combined table (TPH) instead of getting from two

            return View(viewModel);
        }

        public ActionResult VerifyCredentials(LoginIndexData model)
        {
            TempData["name"] = model.name;
            TempData["pass"] = model.password;
            return RedirectToAction("Index", "Home" );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
