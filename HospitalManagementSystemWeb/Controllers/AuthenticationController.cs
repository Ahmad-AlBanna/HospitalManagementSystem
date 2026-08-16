using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemWeb.Controllers;


public class AuthenticationController : Controller
{

    public IActionResult Login()
    {
        return View();
    }

}
