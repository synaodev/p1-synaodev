using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Order : AModel {
		public long OrderID { get; set; }
		public long UserID { get; set; }
		public long StoreID { get; set; }
		public DateTime DateTime { get; set; }
		public bool Completed { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Price {
			get {
				return Math.Min(
					OrderPizzas.Sum(op => op.Pizza.Price), 
					250.00M
				);
			}
		}
		#region NAVIGATIONAL PROPERTIES
		public User User { get; set; }
		public Store Store { get; set; }
		public List<OrderPizza> OrderPizzas { get; set; }
		#endregion
		public Order() {
			OrderID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return OrderID;
		}
		public override string ToString() {
			string result = $"Time: {DateTime} User: {User.Username} Store At: {Store.Location} Pizzas: ";
			foreach (OrderPizza op in OrderPizzas) {
				Pizza p = op.Pizza;
				result += $"{op.ToString()} ";
			}
			result += $"Price Total: {Price}";
			return result;
		}
	}
}