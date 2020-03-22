using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class StoreRepository : ARepository<Store> {
		public StoreRepository(PizzaBoxDbContext context) : base(context, context.Stores) {

		}
		public override List<Store> Get() {
			return Table.Include(s => s.Orders).ToList();
		}
		public override Store Get(long ID) {
			return Table.SingleOrDefault(s => s.StoreID == ID);
		}
	}
}