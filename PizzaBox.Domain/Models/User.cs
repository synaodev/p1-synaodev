using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models {
	public class User : AModel {
		public long UserID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		#region NAVIGATION PROPERTIES
		public List<Order> Orders { get; set; }
		#endregion
		public User() {
			UserID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return UserID;
		}
	}
}