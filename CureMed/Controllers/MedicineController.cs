using Microsoft.AspNetCore.Mvc;

namespace CureMed.Controllers
{
    public class MedicineController : Controller
    {
        public MedicineController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
