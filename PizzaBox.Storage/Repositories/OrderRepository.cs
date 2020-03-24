using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class OrderRepository : ARepository<Order> {
		public OrderRepository(PizzaBoxDbContext context) : base(context.Orders) {

		}
		public override List<Order> Get() {
			return Table
				.Include(o => o.User)
				.Include(o => o.Store)
				.Include(o => o.OrderPizzas)
				.ThenInclude(op => op.Pizza)
				.OrderByDescending(o => o.DateTime)
			.ToList();
		}
		public override Order Get(long ID) {
			return Table.SingleOrDefault(o => o.OrderID == ID);
		}
		public List<Order> FindByUser(User user) {
			return Table
				.Where(o => o.UserID == user.UserID)
				.Include(o => o.Store)
				.Include(o => o.OrderPizzas)
				.ThenInclude(op => op.Pizza)
				.OrderByDescending(o => o.DateTime)
			.ToList();
		}
		public List<Order> FindByStore(Store store) {
			return Table
				.Where(o => o.StoreID == store.StoreID)
				.Include(o => o.User)
				.Include(o => o.OrderPizzas)
				.ThenInclude(op => op.Pizza)
				.OrderByDescending(o => o.DateTime)
			.ToList();
		}
		public List<Order> FindByUserAndStore(User user, Store store) {
			return Table
				.Where(o => o.UserID == user.UserID && o.StoreID == store.StoreID)
				.Include(o => o.OrderPizzas)
				.ThenInclude(op => op.Pizza)
				.OrderByDescending(o => o.DateTime)
			.ToList();
		}
	}
}