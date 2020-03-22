using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public abstract class ARepository<T> where T : AModel {
		protected DbSet<T> Table = null;
		public ARepository(DbSet<T> table) {
			Table = table;
		}
		public abstract List<T> Get();
		public abstract T Get(long ID);
		public bool Post(T entity, PizzaBoxDbContext ctx) {
			Table.Add(entity);
			return ctx.SaveChanges() >= 1;
		}
		public bool Put(T right, PizzaBoxDbContext ctx) {
			T left = this.Get(right.GetID());
			left = right;
			return ctx.SaveChanges() >= 1;
		}
		public bool Delete(T entity, PizzaBoxDbContext ctx) {
			Table.Remove(entity);
			return ctx.SaveChanges() >= 1;
		}
	}
}