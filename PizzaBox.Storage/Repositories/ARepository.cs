using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories {
	public abstract class ARepository<T> where T : AModel {
		protected PizzaBoxDbContext Context = null;
		public ARepository(PizzaBoxDbContext context) {
			Context = context;
		}
		/*public virtual List<T> Get() {
			return Context.Set<T>().ToList();
		}
		public virtual T Get(long ID) {
			return Context.Set<T>().SingleOrDefault(t => t.GetID() == ID);
		}*/
		public abstract List<T> Get();
		public abstract T Get(long ID);
		public bool Post(T entity) {
			Context.Set<T>().Add(entity);
			return Context.SaveChanges() >= 1;
		}
		public bool Put(T right) {
			T left = this.Get(right.GetID());
			left = right;
			return Context.SaveChanges() >= 1;
		}
		public bool Delete(T entity) {
			Context.Set<T>().Remove(entity);
			return Context.SaveChanges() >= 1;
		}
	}
}