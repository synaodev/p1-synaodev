using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class StoreRepository : ARepository<Store> {
		public StoreRepository(PizzaBoxDbContext context) : base(context) {

		}
		public override List<Store> Get() {
			return Context.Set<Store>().Include(s => s.Orders).ToList();
		}
		public override Store Get(long ID) {
			return Context.Set<Store>().SingleOrDefault(s => s.StoreID == ID);
		}
	}
}