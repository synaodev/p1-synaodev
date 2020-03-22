using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Crust : APizzaComponent {
		public long CrustID { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public List<Pizza> Pizzas { get; set; }
		#endregion
		public Crust() {
			CrustID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return CrustID;
		}
	}
}