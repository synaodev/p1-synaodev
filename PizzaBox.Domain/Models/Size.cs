using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Size : APizzaComponent {
		public long SizeID { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public List<Pizza> Pizzas { get; set; }
		#endregion
		public Size() {
			SizeID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return SizeID;
		}
	}
}