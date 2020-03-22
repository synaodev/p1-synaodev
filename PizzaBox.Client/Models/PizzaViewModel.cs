using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Models {
	public class PizzaViewModel {
		private PizzeriaService _ps;
		public PizzaViewModel(PizzeriaService ps) {
			_ps = ps;
		}
		public List<Crust> CrustList { get; set; }
		public List<Size> SizeList { get; set; }
		public List<Topping> ToppingList { get; set; }
		public Crust Crust { get; set; }
		public Size Size { get; set; }
		public List<Topping> Toppings { get; set; }
		public PizzaViewModel() {
			// CrustList = _pbr.Read<Crust>().ToList();
			// SizeList = _pbr.Read<Size>().ToList();
			// ToppingList = _pbr.Read<Topping>().ToList();
			CrustList = _ps.GetCrusts();
			SizeList = _ps.GetSizes();
			ToppingList = _ps.GetToppings();
		}
	}
}