using System.ComponentModel.DataAnnotations;

namespace CafeComASup.Models
{
    public class Enquetes
    {
		public int Id { get; set; }

		public int EventoId { get; set; }

		[StringLength(60)]
		public string? Titulo { get; set; }

		[StringLength(200)]
		public string? Descricao { get; set; }

		public DateTime DataInicio { get; set; }

		public DateTime DataFim { get; set; }
		public bool Ativo { get; set; }
	}
}
