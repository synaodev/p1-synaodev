
namespace PizzaBox.Domain.Abstracts {
	public abstract class APizzaComponent : AModel {
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}