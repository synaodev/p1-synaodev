using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class SizeRepository : ARepository<Size> {
		public SizeRepository(PizzaBoxDbContext context) : base(context) {

		}
		public override List<Size> Get() {
			return Context.Set<Size>().Include(s => s.Pizzas).ToList();
		}
		public override Size Get(long ID) {
			return Context.Set<Size>().SingleOrDefault(s => s.SizeID == ID);
		}
	}
}