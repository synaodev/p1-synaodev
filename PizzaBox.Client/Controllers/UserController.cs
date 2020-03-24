using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;
using PizzaBox.Client.Utility;

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
		private List<Pizza> ConvertFakePizzas(List<Pizza> fake_pizzas) {
			List<Pizza> real_pizzas = new List<Pizza>();
			foreach (var f in fake_pizzas) {
				Pizza r = _ps.GetPizza(f.PizzaID);
				real_pizzas.Add(r);
			}
			return real_pizzas;
		}
		[HttpGet]
		public IActionResult Index() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Account/Logout");
			}
			ViewData["Username"] = user.Username;
			List<Pizza> cart = SessionSerializer.FromJson<List<Pizza>>(HttpContext.Session, "Cart");
			if (cart == null) {
				cart = new List<Pizza>();
			}
			return View(new UserViewModel(_ps, user, cart));
		}
		[HttpGet]
		public IActionResult History() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Account/Logout");
			}
			List<Pizza> cart = SessionSerializer.FromJson<List<Pizza>>(HttpContext.Session, "Cart");
			if (cart == null) {
				cart = new List<Pizza>();
			}
			return View(new UserViewModel(_ps, user, cart));
		}
		[HttpGet]
		public IActionResult Order() {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Account/Logout");
			}
			List<Pizza> cart = SessionSerializer.FromJson<List<Pizza>>(HttpContext.Session, "Cart");
			if (cart == null) {
				cart = new List<Pizza>();
			}
			return View(new UserViewModel(_ps, user, cart));
		}
		[HttpPost]
		public IActionResult Cart(UserViewModel uvm) {
			Pizza pizza = _ps.GetPizzaFake(uvm.PizzaID);
			if (pizza != null) {
				List<Pizza> cart = SessionSerializer.FromJson<List<Pizza>>(HttpContext.Session, "Cart");
				if (cart == null) {
					cart = new List<Pizza>();
				}
				cart.Add(pizza);
				SessionSerializer.ToJson(HttpContext.Session, "Cart", cart);
			}
			return Redirect("/User/Order");
		}
		[HttpPost]
		public IActionResult Order(UserViewModel uvm) {
			User user = GetCurrentUser();
			if (user == null) {
				return Redirect("/Account/Logout");
			}
			Store store = _ps.GetStore(uvm.StoreID);
			if (store == null) {
				return View(uvm);
			}
			List<Pizza> cart = SessionSerializer.FromJson<List<Pizza>>(HttpContext.Session, "Cart");
			if (cart == null || cart.Count == 0 || cart.Count == 50) {
				return View(uvm);
			}
			List<Pizza> real_pizzas = ConvertFakePizzas(cart);
			if (!_ps.PostOrder(user, store, real_pizzas)) {
				return View(uvm);
			}
			HttpContext.Session.Remove("Cart");
			return Redirect("/User/Index");
		}
	}
}