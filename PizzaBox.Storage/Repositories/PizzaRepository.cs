using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class PizzaRepository : ARepository<Pizza> {
		public PizzaRepository(PizzaBoxDbContext context) : base(context) {

		}
		public override List<Pizza> Get() {
			return Context.Set<Pizza>()
				.Include(p => p.Crust)
				.Include(p => p.Size)
				.Include(p => p.PizzaToppings)
				.ThenInclude(pt => pt.Topping)
				.Include(p => p.OrderPizzas)
				.ThenInclude(op => op.Order)
			.ToList();
		}
		public override Pizza Get(long ID) {
			return Context.Set<Pizza>().SingleOrDefault(p => p.PizzaID == ID);
		}
		public List<Crust> GetCrusts() {
			return Context.Set<Crust>().Include(c => c.Pizzas).ToList();
		}
		public List<Size> GetSizes() {
			return Context.Set<Size>().Include(s => s.Pizzas).ToList();
		}
		public List<Topping> GetToppings() {
			return Context.Set<Topping>()
				.Include(t => t.PizzaToppings)
				.ThenInclude(pt => pt.Pizza)
			.ToList();
		}
		public object CheckAccount(string user, string password) {
			return new object();
		}
	}
}