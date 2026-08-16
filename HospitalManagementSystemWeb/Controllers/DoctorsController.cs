using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemWeb.Controllers
{
    public class DoctorsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

    }

}
