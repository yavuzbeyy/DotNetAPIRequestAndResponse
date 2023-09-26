using ETicaret.Models;
using ETicaret.MVC.Models;
using ETicaret.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ETicaret.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Context db = new Context();

        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7160/api/");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adres()
        {
            var AdresListesi = db.Adresses.ToList();
            return View(AdresListesi);
        }

        public IActionResult User()
        {
            var userListesi = db.Users.ToList();
            return View(userListesi);
        }

        public async Task<IActionResult> Product()
        {
        https://localhost:7160/api/Product
            HttpResponseMessage response = await _httpClient.GetAsync("Product");
            
            if (response.IsSuccessStatusCode) //200 ise
            {
                var products = await response.Content.ReadFromJsonAsync<List<Product>>();
                return View(products);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> ProductSil(int id) {

            HttpResponseMessage response = await _httpClient.DeleteAsync($"Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Product");
            }
            else { return RedirectToAction("Index"); }
          }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

}
}