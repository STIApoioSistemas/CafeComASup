namespace CafeComASup.Models
{
	public class Reservas
	{
		public int Id { get; set; }

		public int EventoId { get; set; }

		public int PessoaId { get; set; }

		public string? Protocolo { get; set; }

		public DateTime DataConfirmacao { get; set; }
	}
}
