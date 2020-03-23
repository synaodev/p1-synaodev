using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class PizzaRepository : ARepository<Pizza> {
		public PizzaRepository(PizzaBoxDbContext context) : base(context.Pizzas) {

		}
		public override List<Pizza> Get() {
			return Table
				.Include(p => p.Crust)
				.Include(p => p.Size)
				.Include(p => p.PizzaToppings)
				.ThenInclude(pt => pt.Topping)
				.Include(p => p.OrderPizzas)
				.ThenInclude(op => op.Order)
			.ToList();
		}
		public List<Pizza> Get(List<long> ids) {
			return Table
				.Where(p => ids.Contains(p.PizzaID))
				.Include(p => p.Crust)
				.Include(p => p.Size)
				.Include(p => p.PizzaToppings)
				.ThenInclude(pt => pt.Topping)
				.Include(p => p.OrderPizzas)
				.ThenInclude(op => op.Order)
			.ToList();
		}
		public override Pizza Get(long ID) {
			return Table.SingleOrDefault(p => p.PizzaID == ID);
		}
	}
}