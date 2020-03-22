using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Store : AModel {
		public long StoreID { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public decimal Revanue {
			get {
				return Orders.Sum(o => o.Completed ? o.Price : 0.0M);
			}
		}
		#region NAVIGATIONAL PROPERTIES
		public List<Order> Orders { get; set; }
		#endregion
		public Store() {
			StoreID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return StoreID;
		}
	}
}