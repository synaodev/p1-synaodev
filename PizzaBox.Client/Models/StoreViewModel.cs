using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Services;

namespace PizzaBox.Client.Models {
	public class StoreViewModel {
		private PizzeriaService _ps;
		public string Username { get; set; }
		public string Location { get; set; }
		public List<Order> Orders { get; set; }
		public List<Pizza> PizzaList { get; set; }
		//public List<Crust> CrustList { get; set; }
		//public List<Size> SizeList { get; set; }
		public decimal Revanue { 
			get {
				return Orders.Sum(o => o.Price);
			}
		}
		public StoreViewModel(PizzeriaService ps, Store store) {
			_ps = ps;
			Username = store.Username;
			Location = store.Location;
			PizzaList = _ps.GetPizzas();
			Orders = _ps.FindOrdersByStore(store);
		}
		public StoreViewModel() {
			
		}
	}
}