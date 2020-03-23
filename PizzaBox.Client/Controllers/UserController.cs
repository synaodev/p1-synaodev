using System.Collections.Generic;
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
				return Redirect("/Account/Logout");
			}
			ViewData["Username"] = user.Username;
			return View(new UserViewModel(_ps, user));
		}
		[HttpGet]
		public IActionResult History() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Account/Logout");
			}
			return View(new UserViewModel(_ps, user));
		}
		[HttpGet]
		public IActionResult Order() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Account/Logout");
			}
			return View(new UserViewModel(_ps, user));
		}
		[HttpPost]
		public IActionResult Order(UserViewModel uvm) {
			if (ModelState.IsValid) {
				List<Pizza> pizzas = new List<Pizza>() { uvm.Pizza };
				if (_ps.PostOrder(uvm.User, uvm.Store, pizzas)) {
					return Redirect("/User/Index");
				}
			}
			return View(uvm);
		}
	}
}