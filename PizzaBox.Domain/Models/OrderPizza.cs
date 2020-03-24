using System;

namespace PizzaBox.Domain.Models {
	public class OrderPizza {
		public long OrderPizzaID { get; set; }
		public long OrderID { get; set; }
		public long PizzaID { get; set; }
		#region NAVIGATION PROPERTIES
		public Order Order { get; set; }
		public Pizza Pizza { get; set; }
		#endregion
		public OrderPizza() {
			OrderPizzaID = DateTime.Now.Ticks;
		}
	}
}