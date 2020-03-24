using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;
using PizzaBox.Client.Utility;

namespace PizzaBox.Client.Controllers {
	public class PizzaController : Controller {
		private PizzeriaService _ps;
		public PizzaController(PizzeriaService ps) {
			_ps = ps;
		}
		[HttpGet]
		public IActionResult Create() {
			long crust_id = 0;
			string crust_string = HttpContext.Session.GetString("CrustID");
			if (crust_string == null) {
				long.TryParse(crust_string, out crust_id);
			}
			long size_id = 0;
			string size_string = HttpContext.Session.GetString("SizeID");
			if (size_string == null) {
				long.TryParse(size_string, out size_id);
			}
			List<Topping> toppings = SessionSerializer.FromJson<List<Topping>>(HttpContext.Session, "Toppings");
			if (toppings == null) {
				toppings = new List<Topping>();
			}
			return View(new PizzaViewModel(_ps, crust_id, size_id, toppings));
		}
		[HttpPost]
		public IActionResult Create(PizzaViewModel pvm) {
			Crust crust = _ps.GetCrust(pvm.CrustID);
			Size size = _ps.GetSize(pvm.SizeID);
			List<Topping> toppings = SessionSerializer.FromJson<List<Topping>>(HttpContext.Session, "Toppings");
			if (crust != null && size != null && toppings != null && toppings.Count >= 2) {
				if (_ps.PostPizza(crust, size, toppings)) {
					HttpContext.Session.Remove("CrustID");
					HttpContext.Session.Remove("SizeID");
					HttpContext.Session.Remove("Toppings");
					return Redirect("/Store/Index");
				}
			}
			HttpContext.Session.SetString("CrustID", pvm.CrustID.ToString());
			HttpContext.Session.SetString("SizeID", pvm.SizeID.ToString());
			return View(pvm);
		}
		[HttpPost]
		public IActionResult Topping(PizzaViewModel pvm) {
			Topping topping = _ps.GetTopping(pvm.ToppingID);
			if (topping != null) {
				List<Topping> toppings = SessionSerializer.FromJson<List<Topping>>(HttpContext.Session, "Toppings");
				if (toppings == null) {
					toppings = new List<Topping>();
				}
				toppings.Add(topping);
				SessionSerializer.ToJson(HttpContext.Session, "Toppings", toppings);
			}
			HttpContext.Session.SetString("CrustID", pvm.CrustID.ToString());
			HttpContext.Session.SetString("SizeID", pvm.SizeID.ToString());
			return Redirect("/Pizza/Create");
		}
	}
}