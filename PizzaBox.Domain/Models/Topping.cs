using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Topping : APizzaComponent {
		public long ToppingID { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public List<PizzaTopping> PizzaToppings { get; set; }
		#endregion
		public Topping() {
			ToppingID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return ToppingID;
		}
	}
}