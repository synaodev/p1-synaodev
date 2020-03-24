using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Models {
	public class PizzaViewModel {
		private PizzeriaService _ps;
		public List<Crust> CrustList { get; set; }
		public List<Size> SizeList { get; set; }
		public List<Topping> ToppingList { get; set; }
		public long CrustID { get; set; }
		public long SizeID { get; set; }
		public long ToppingID { get; set; }
		public List<Topping> Toppings { get; set; }
		public decimal Price {
			get {
				decimal result = 0.0M;
				if (CrustID != 0) {
					Crust crust = _ps.GetCrust(CrustID);
					result += crust.Price;
				}
				if (SizeID != 0) {
					Size size = _ps.GetSize(SizeID);
					result += size.Price;
				}
				if (Toppings != null && Toppings.Count > 0) {
					result += Toppings.Sum(t => t.Price);
				}
				return result;
			}
		}
		public PizzaViewModel() {

		}
		public PizzaViewModel(PizzeriaService ps, long crust_id, long size_id, List<Topping> toppings) {
			_ps = ps;
			CrustID = crust_id;
			SizeID = size_id;
			CrustList = _ps.GetCrusts();
			SizeList = _ps.GetSizes();
			ToppingList = _ps.GetToppings();
			Toppings = toppings;
		}
	}
}