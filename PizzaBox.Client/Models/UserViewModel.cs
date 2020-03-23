using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Models {
	public class UserViewModel {
		private static PizzeriaService _ps;
		public User User { get; set; }
		public List<Order> OrderList { get; set; }
		public List<Store> StoreList { get; set; }
		public List<Pizza> PizzaList { get; set; }
		[Required]
		public Store Store { get; set; }
		[Required]
		public Pizza Pizza { get; set; }
		public UserViewModel(PizzeriaService ps, User user) {
			_ps = ps;
			User = user;
			OrderList = _ps.FindOrdersByUser(User);
			StoreList = _ps.GetStores();
			PizzaList = _ps.GetPizzas();
		}
		public UserViewModel() {
			
		}
	}
}