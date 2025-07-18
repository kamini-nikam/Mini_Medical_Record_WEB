using Microsoft.AspNetCore.Mvc;

namespace Mini_Medical_Record_WEB.Controllers
{
    public class Medical_DashboardController : Controller
    {
        public IActionResult Mini_Dashboard()
        {
            return View();
        }
    }
}
