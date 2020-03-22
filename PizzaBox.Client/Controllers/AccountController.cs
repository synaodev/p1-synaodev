using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Controllers {
	public class AccountController : Controller {
		private PizzaRepository _pbr;
		public AccountController(PizzaRepository pbr) {
			_pbr = pbr;
		}
		[HttpGet]
		public IActionResult Login() {
			return View();
		}
		[HttpPost]
		public IActionResult Login(AccountViewModel account) {
			if (ModelState.IsValid) {
				var acct = _pbr.CheckAccount(account.Username, account.Password);
				if (acct != null) {
					if (account.User) {
						return View("User", acct);
					}
					return View("Store", acct);
				}
			}
			return View(account);
		}
	}
}
