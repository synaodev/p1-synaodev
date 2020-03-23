using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Controllers {
	public class UserController : Controller {
		private PizzeriaService _ps;
		public UserController(PizzeriaService ps) {
			_ps = ps;
		}
		private User GetCurrentUser() {
			int? admin = HttpContext.Session.GetInt32("AcctAdmin");
			if (admin == null) {
				return null;
			} else if (admin.Value == 1) {
				return null;
			}
			string acct_id = HttpContext.Session.GetString("AcctID");
			if (acct_id.Length == 0) {
				return null;
			}
			long user_id = 0;
			if (!long.TryParse(acct_id, out user_id)) {
				return null;
			}
			return _ps.GetUser(user_id);
		}
		[HttpGet]
		public IActionResult Index() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Home/Index");
			}
			return View(new UserViewModel(_ps, user));
		}
		[HttpGet]
		public IActionResult History() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Home/Index");
			}
			return View(new UserViewModel(_ps, user));
		}
		[HttpGet]
		public IActionResult Order() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Home/Index");
			}
			return View(new UserViewModel(_ps, user));
		}
		[HttpPost]
		public IActionResult Order(UserViewModel uvm) {
			return View(uvm);
		}
	}
}