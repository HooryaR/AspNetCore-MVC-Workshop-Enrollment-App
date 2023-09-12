using Assignment2EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment2EF.Controllers
{
    public class HomeController : Controller
    {
        private IWorkshopRepo workshopRepo;

        public HomeController(IWorkshopRepo workshopRepo)
        {
            this.workshopRepo = workshopRepo;
        }

        /*
        private void AddErrorsFromModel(ModelStateDictionary.ValueEnumerable values)
        {
            foreach (ModelStateEntry modelState in values)
                foreach (ModelError error in modelState.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.ErrorMessage.ToString());

                }
        }*/

        public async Task<IActionResult> Index()
        {
            
            return View(workshopRepo.GetWorkshops);
        }

        [HttpGet]
        public IActionResult Enroll()
        {
            return View("EnrollForm");
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(Enrollement enrollement)
        {
            if (ModelState.IsValid)
            {
                if (RouteData.Values["id"].ToString() == "1")
                {
                    int workID = 1;
                    workshopRepo.AddEnrollement(enrollement, workID);
                    workshopRepo.Save();
                }
                else if (RouteData.Values["id"].ToString() == "2")
                {
                    int workID = 2;
                    workshopRepo.AddEnrollement(enrollement, workID);
                    workshopRepo.Save();
                }
                else if (RouteData.Values["id"].ToString() == "3")
                {
                    int workID = 3;
                    workshopRepo.AddEnrollement(enrollement, workID);
                    workshopRepo.Save();
                }
                return RedirectToAction("Index");
            }
            //AddErrorsFromModel(ModelState.Values);
            return View("EnrollForm");
            
        }

        [HttpGet]
        public IActionResult MyWorkshops()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MyWorkshops(string email)
        {
            

            if (workshopRepo.GetEnrollements.
                Where(e => e.Email == email).OrderBy(e => e.EnrollementId).Any() == true)
            {
                ViewBag.ShowMsg = false;
            }
            else
            {
                ViewBag.ShowMsg = true;
            }

            return View(workshopRepo.GetEnrollements.
                Where(e=>e.Email == email)
                .OrderBy(e=>e.EnrollementId));
            
        }
    }
}
