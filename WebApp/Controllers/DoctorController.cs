using WebApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet("Doctor/FeverCheck")]
        public IActionResult FeverCheck()
        {
            return View();
        }
        
        [HttpPost("Doctor/FeverCheck")]
        public IActionResult FeverCheck(float temperature)
        {
            ViewBag.message = FeverCheckerModel.Fever(temperature);
            return View();
        }
    }
}
