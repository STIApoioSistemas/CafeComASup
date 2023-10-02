using System.ComponentModel.DataAnnotations;

namespace CafeComASup.Models
{
    public class Eventos
    {
        public int Id { get; set; }

		[StringLength(60)]
		public string? Titulo { get; set; }
		
        [StringLength(120)]
		public string? Descricao { get; set;}

        public bool Ativo { get; set; }

        public DateTime DataEvento { get; set; }

        public int Vagas{ get; set; }
    }
}
