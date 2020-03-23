using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }
        public IActionResult Index() {
            string acct_id = HttpContext.Session.GetString("AcctID");
            if (acct_id != null) {
                int? admin = HttpContext.Session.GetInt32("AcctAdmin");
                if (admin != null) {
                    if (admin.Value == 0) {
                        return Redirect("/User/Index");
                    } else if (admin.Value == 1) {
                        return Redirect("/Store/Index");
                    }
                }
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
