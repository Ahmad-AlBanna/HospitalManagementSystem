using HospitalManagementSystemWeb.Services.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemWeb.Controllers;

public class AppointmentsController : Controller
{
    private readonly SecureIdService _secureIdService;


    public AppointmentsController(
        SecureIdService secureIdService)
    {
        _secureIdService = secureIdService;
    }

    [HttpGet]
    public IActionResult ProtectId(int id)
    {
        var protectedId =
            _secureIdService.Protect(id);

        return Ok(protectedId);
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Create()
    {
        return View();
    }


    public IActionResult Edit(string id)
    {
        var appointmentId =
            _secureIdService.Unprotect(id);

        ViewBag.AppointmentId = appointmentId;



        return View();
    }
}