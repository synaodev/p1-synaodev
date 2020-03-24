using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Controllers {
	public class AccountController : Controller {
		private PizzeriaService _ps;
		public AccountController(PizzeriaService ps) {
			_ps = ps;
		}
		[HttpGet]
		public IActionResult Login() {
			return View();
		}
		[HttpPost]
		public IActionResult Login(AccountViewModel account) {
			if (ModelState.IsValid) {
				if (account.Admin) {
					Store store = _ps.FindStoreByName(account.Username);
					if (store != null) {
						if (store.Password == account.Password) {
							HttpContext.Session.SetString("AcctID", store.StoreID.ToString());
							HttpContext.Session.SetInt32("AcctAdmin", 1);
							return Redirect("/Store/Index");
						}
					}
				} else {
					User user = _ps.FindUserByName(account.Username);
					if (user != null) {
						if (user.Password == account.Password) {
							HttpContext.Session.SetString("AcctID", user.UserID.ToString());
							HttpContext.Session.SetInt32("AcctAdmin", 0);
							return Redirect("/User/Index");
						}
					}
				}
			}
			return View(account);
		}
		[HttpGet]
		public IActionResult Logout() {
			HttpContext.Session.Remove("AcctID");
			HttpContext.Session.Remove("AcctAdmin");
			HttpContext.Session.Remove("Cart");
			HttpContext.Session.Remove("CrustID");
			HttpContext.Session.Remove("SizeID");
			HttpContext.Session.Remove("Toppings");
			return Redirect("/Home/Index");
		}
	}
}
