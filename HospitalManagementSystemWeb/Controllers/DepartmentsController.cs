using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemWeb.Controllers
{
    public class DepartmentsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }

}
