
namespace PizzaBox.Domain.Models {
	public class PizzaTopping {
		public long PizzaID { get; set; }
		public long ToppingID { get; set; }
		#region NAVIGATION PROPERTIES
		public Pizza Pizza { get; set; }
		public Topping Topping { get; set; }
		#endregion
	}
}