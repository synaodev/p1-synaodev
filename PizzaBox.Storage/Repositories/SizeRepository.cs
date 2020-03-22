using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class SizeRepository : ARepository<Size> {
		public SizeRepository(PizzaBoxDbContext context) : base(context.Sizes) {

		}
		public override List<Size> Get() {
			return Table.Include(s => s.Pizzas).ToList();
		}
		public override Size Get(long ID) {
			return Table.SingleOrDefault(s => s.SizeID == ID);
		}
	}
}