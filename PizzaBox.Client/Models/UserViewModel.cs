using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Models {
	public class UserViewModel {
		private PizzeriaService _ps;
		public string Username { get; set; }
		public List<Order> Orders { get; set; }
		public UserViewModel(PizzeriaService ps, User user) {
			_ps = ps;
			Username = user.Username;
			Orders = _ps.FindOrdersByUser(user);
		}
	}
}