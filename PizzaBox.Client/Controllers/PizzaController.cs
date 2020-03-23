using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers {
	public class PizzaController : Controller {
		private PizzeriaService _ps;
		public PizzaController(PizzeriaService ps) {
			_ps = ps;
		}
		[HttpGet]
		public IActionResult Read() {
			return View();
		}
		[HttpGet]
		public IActionResult Create() {
			return View(new PizzaViewModel(_ps));
		}
		[HttpPost]
		public IActionResult Create(PizzaViewModel pizzaViewModel) {
			return View();
		}
	}
}