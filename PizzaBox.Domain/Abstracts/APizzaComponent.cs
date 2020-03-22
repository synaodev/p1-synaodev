using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBox.Domain.Abstracts {
	public abstract class APizzaComponent : AModel {
		public string Name { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Price { get; set; }
	}
}