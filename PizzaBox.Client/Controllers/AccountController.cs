using Microsoft.AspNetCore.Mvc;
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
				if (account.User) {
					User user = _ps.FindUserByName(account.Username);
					if (user != null) {
						if (user.Password == account.Password) {
							return View("User", user);
						}
					}
				} else {
					Store store = _ps.FindStoreByName(account.Username);
					if (store != null) {
						if (store.Password == account.Password) {
							return View("Store", store);
						}
					}
				}
			}
			return View(account);
		}
	}
}
