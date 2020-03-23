using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Models {
	public class PizzaViewModel {
		private PizzeriaService _ps;
		public List<Crust> CrustList { get; set; }
		public List<Size> SizeList { get; set; }
		public List<Topping> ToppingList { get; set; }
		public Crust Crust { get; set; }
		public Size Size { get; set; }
		public List<Topping> Toppings { get; set; }
		public PizzaViewModel(PizzeriaService ps) {
			_ps = ps;
			CrustList = _ps.GetCrusts();
			SizeList = _ps.GetSizes();
			ToppingList = _ps.GetToppings();
		}
		public PizzaViewModel() {
			
		}
	}
}