using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public class UserRepository : ARepository<User> {
		public UserRepository(PizzaBoxDbContext context) : base(context) {

		}
		public override List<User> Get() {
			return Context.Set<User>().Include(u => u.Orders).ToList();
		}
		public override User Get(long ID) {
			return Context.Set<User>().SingleOrDefault(u => u.UserID == ID);
		}
		public User FindByName(string username) {
			return Context.Set<User>().Where(u => u.Username == username).First();
		}
	}
}