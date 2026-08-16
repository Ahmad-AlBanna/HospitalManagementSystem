using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemWeb.Controllers;


public class AdminController : Controller
{

    public IActionResult Dashboard()
    {
        return View();
    }

}
