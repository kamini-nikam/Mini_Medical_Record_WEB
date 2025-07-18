using Microsoft.AspNetCore.Mvc;
using Mini_Medical_Record_WEB.Models;

namespace Mini_Medical_Record_WEB.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _httpClient.PostAsJsonAsync("api/auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Mini_Dashboard", "Medical_Dashboard");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _httpClient.PostAsJsonAsync("api/auth/register", model);

            if (response.IsSuccessStatusCode)
            {
                // Optional: Display a success message or redirect to login
                TempData["Success"] = "Registration successful. Please log in.";
                return RedirectToAction("Index", "Auth");
            }

            ModelState.AddModelError(string.Empty, "Registration failed.");
            return View(model);
        }

    }
}
