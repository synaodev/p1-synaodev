using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class CrustRepository : ARepository<Crust> {
		public CrustRepository(PizzaBoxDbContext context) : base(context) {
			
		}
		public override List<Crust> Get() {
			return Context.Set<Crust>().Include(c => c.Pizzas).ToList();
		}
		public override Crust Get(long ID) {
			return Context.Set<Crust>().SingleOrDefault(c => c.CrustID == ID);
		}
	}
}
