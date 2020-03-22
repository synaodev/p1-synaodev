using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public abstract class ARepository<T> where T : AModel {
		protected PizzaBoxDbContext Context = null;
		protected DbSet<T> Table = null;
		public ARepository(PizzaBoxDbContext context, DbSet<T> table) {
			Context = context;
			Table = table;
		}
		public virtual List<T> Get() {
			return Table.ToList();
		}
		public virtual T Get(long ID) {
			return Table.SingleOrDefault(t => t.GetID() == ID);
		}
		public bool Post(T entity) {
			Table.Add(entity);
			return Context.SaveChanges() >= 1;
		}
		public bool Put(T right) {
			long ID = right.GetID();
			T left = Get(ID);
			left = right;
			return Context.SaveChanges() >= 1;
		}
		public bool Delete(T entity) {
			Table.Remove(entity);
			return Context.SaveChanges() >= 1;
		}
	}
}