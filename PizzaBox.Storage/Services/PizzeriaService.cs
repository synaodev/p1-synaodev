using System; 
using System.Collections.Generic; 
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Storage.Services {
	public class PizzeriaService {
		public PizzeriaService(PizzaBoxDbContext context) {
			_ctx = context;
			_pr = new PizzaRepository(context);
			_cr = new CrustRepository(context);
			_sr = new SizeRepository(context);
			_tr = new ToppingRepository(context);
			_ur = new UserRepository(context);
			_or = new OrderRepository(context);
			_rr = new StoreRepository(context);
		}
		private PizzaBoxDbContext _ctx;
		private PizzaRepository _pr;
		private CrustRepository _cr;
		private SizeRepository _sr;
		private ToppingRepository _tr;
		private UserRepository _ur;
		private OrderRepository _or;
		private StoreRepository _rr;
		// GET ALL
		public List<Pizza> GetPizzas() {
			return _pr.Get();
		}
		public List<Crust> GetCrusts() {
			return _cr.Get();
		}
		public List<Size> GetSizes() {
			return _sr.Get();
		}
		public List<Topping> GetToppings() {
			return _tr.Get();
		}
		public List<User> GetUsers() {
			return _ur.Get();
		}
		public List<Order> GetOrders() {
			return _or.Get();
		}
		public List<Store> GetStores() {
			return _rr.Get();
		}
		// GET ONE
		public Pizza GetPizza(long ID) {
			return _pr.Get(ID);
		}
		public Crust GetCrust(long ID) {
			return _cr.Get(ID);
		}
		public Size GetSize(long ID) {
			return _sr.Get(ID);
		}
		public Topping GetTopping(long ID) {
			return _tr.Get(ID);
		}
		public User GetUser(long ID) {
			return _ur.Get(ID);
		}
		public Order GetOrder(long ID) {
			return _or.Get(ID);
		}
		public Store GetStore(long ID) {
			return _rr.Get(ID);
		}
		// POST
		public bool PostPizza(Crust crust, Size size, List<Topping> toppings) {
			Pizza p = new Pizza() {
				CrustID = crust.CrustID,
				SizeID = size.SizeID,
				PizzaToppings = new List<PizzaTopping>()
			};
			foreach (Topping t in toppings) {
				p.PizzaToppings.Add(new PizzaTopping() {
					PizzaID = p.PizzaID,
					ToppingID = t.ToppingID
				});
				t.PizzaToppings.Add(new PizzaTopping() {
					PizzaID = p.PizzaID,
					ToppingID = t.ToppingID
				});
			}
			return _pr.Post(p, _ctx);
		}
		public bool PostCrust(string name, decimal price) {
			Crust c = new Crust() {
				Name = name,
				Price = price
			};
			return _cr.Post(c, _ctx);
		}
		public bool PostSize(string name, decimal price) {
			Size s = new Size() {
				Name = name,
				Price = price
			};
			return _sr.Post(s, _ctx);
		}
		public bool PostTopping(string name, decimal price) {
			Topping t = new Topping() {
				Name = name,
				Price = price
			};
			return _tr.Post(t, _ctx);
		}
		public bool PostUser(string username, string password) {
			User u = new User() {
				Username = username,
				Password = password
			};
			return _ur.Post(u, _ctx);
		}
		public bool PostOrder(User user, Store store, DateTime datetime, List<Pizza> pizzas) {
			Order o = new Order() {
				UserID = user.UserID,
				StoreID = store.StoreID,
				DateTime = datetime,
				Completed = false,
				OrderPizzas = new List<OrderPizza>()
			};
			foreach (Pizza p in pizzas) {
				o.OrderPizzas.Add(new OrderPizza() {
					OrderID = o.OrderID,
					PizzaID = p.PizzaID
				});
				p.OrderPizzas.Add(new OrderPizza() {
					OrderID = o.OrderID,
					PizzaID = p.PizzaID
				});
			}
			return _or.Post(o, _ctx);
		}
		public bool PostStore(string username, string password, string location) {
			Store r = new Store() {
				Username = username,
				Password = password,
				Location = location
			};
			return _rr.Post(r, _ctx);
		}
		// PUT
		public bool PutPizza(Pizza p) {
			return _pr.Put(p, _ctx);
		}
		public bool PutCrust(Crust c) {
			return _cr.Put(c, _ctx);
		}
		public bool PutSize(Size s) {
			return _sr.Put(s, _ctx);
		}
		public bool PutTopping(Topping t) {
			return _tr.Put(t, _ctx);
		}
		public bool PutUser(User u) {
			return _ur.Put(u, _ctx);
		}
		public bool PutOrder(Order o) {
			return _or.Put(o, _ctx);
		}
		public bool PutStore(Store s) {
			return _rr.Put(s, _ctx);
		}
		// DELETE
		public bool DeletePizza(Pizza p) {
			return _pr.Delete(p, _ctx);
		}
		public bool DeleteCrust(Crust c) {
			return _cr.Delete(c, _ctx);
		}
		public bool DeleteSize(Size s) {
			return _sr.Delete(s, _ctx);
		}
		public bool DeleteTopping(Topping t) {
			return _tr.Delete(t, _ctx);
		}
		public bool DeleteUser(User u) {
			return _ur.Delete(u, _ctx);
		}
		public bool DeleteOrder(Order o) {
			return _or.Delete(o, _ctx);
		}
		public bool DeleteStore(Store s) {
			return _rr.Delete(s, _ctx);
		}
		// OTHER
		public User FindUserByName(string username) {
			return _ur.FindByName(username);
		}
		public Store FindStoreByName(string username) {
			return _rr.FindByName(username);
		}
	}
}