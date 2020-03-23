using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Pizza : AModel {
		public long PizzaID { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Price {
			get {
				if (Crust == null || Size == null || PizzaToppings == null) {
					return 0;
				}
				return Crust.Price + Size.Price + PizzaToppings.Sum(t => t.Topping.Price);
			}
		}
		public string Name {
			get {
				if (Crust == null || Size == null) {
					return "";
				}
				return $"{Crust.Name} {Size.Name}";
			}
		}
		public long CrustID { get; set; }
		public long SizeID { get; set; }
		#region NAVIGATIONAL PROPERTIES
		public Crust Crust { get; set; }
		public Size Size { get; set; }
		public List<PizzaTopping> PizzaToppings { get; set; }
		public List<OrderPizza> OrderPizzas { get; set; }
		#endregion
		public Pizza() {
			PizzaID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return PizzaID;
		}
		public override string ToString() {
			string result = $"{Crust.Name} {Size.Name} ";
			foreach (PizzaTopping pt in PizzaToppings) {
				if (pt.Topping != null) {
					result += $"{pt.Topping.Name} ";
				}
			}
			return result;
		}
	}
}