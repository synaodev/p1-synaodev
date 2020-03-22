using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class OrderRepository : ARepository<Order> {
		public OrderRepository(PizzaBoxDbContext context) : base(context) {

		}
		public override List<Order> Get() {
			return Context.Set<Order>()
				.Include(o => o.User)
				.Include(o => o.Store)
				.Include(o => o.OrderPizzas)
				.ThenInclude(op => op.Pizza)
			.ToList();
		}
		public override Order Get(long ID) {
			return Context.Set<Order>().SingleOrDefault(o => o.OrderID == ID);
		}
	}
}