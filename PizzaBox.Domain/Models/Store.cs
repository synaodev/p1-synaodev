using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class Store : AModel {
		public long StoreID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Location { get; set; }
		[Column(TypeName = "decimal(18,4)")]
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