using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Controllers {
	public class StoreController : Controller {
		private PizzeriaService _ps;
		public StoreController(PizzeriaService ps) {
			_ps = ps;
		}
		private Store GetCurrentStore() {
			int? admin = HttpContext.Session.GetInt32("AcctAdmin");
			if (admin == null) {
				return null;
			} else if (admin.Value == 0) {
				return null;
			}
			string acct_id = HttpContext.Session.GetString("AcctID");
			if (acct_id.Length == 0) {
				return null;
			}
			long store_id = 0;
			if (!long.TryParse(acct_id, out store_id)) {
				return null;
			}
			return _ps.GetStore(store_id);
		}
		[HttpGet]
		public IActionResult Index() {
			Store store = GetCurrentStore();
			if (store == null) {
				return Redirect("/Home/Index");
			}
			return View(new StoreViewModel(_ps, store));
		}
		[HttpGet]
		public IActionResult History() {
			Store store = GetCurrentStore();
			if (store == null) {
				return Redirect("/Home/Index");
			}
			return View(new StoreViewModel(_ps, store));
		}
	}
}