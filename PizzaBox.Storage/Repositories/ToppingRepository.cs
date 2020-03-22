using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class ToppingRepository : ARepository<Topping> {
		public ToppingRepository(PizzaBoxDbContext context) : base(context.Toppings) {

		}
		public override List<Topping> Get() {
			return Table
				.Include(t => t.PizzaToppings)
				.ThenInclude(pt => pt.Pizza)
			.ToList();
		}
		public override Topping Get(long ID) {
			return Table.SingleOrDefault(t => t.ToppingID == ID);
		}
	}
}