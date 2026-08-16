using HospitalManagementSystemWeb.Services.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemWeb.Controllers
{
    public class DoctorController : Controller
    {
        private readonly SecureIdService _secureIdService;

        public DoctorController(
      SecureIdService secureIdService)
        {
            _secureIdService = secureIdService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Profile()
        {
            return View();
        }


        public IActionResult Appointments()
        {
            return View();
        }

        public IActionResult PatientHistory(string id)
        {

            var patientId =
                _secureIdService.Unprotect(id);


            ViewBag.PatientId = patientId;


            return View();

        }
    }
}