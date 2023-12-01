using System.ComponentModel.DataAnnotations;

namespace CafeComASup.Models
{
    public class RespostasEnquetes
    {
        public int Id { get; set; }
        public int EnqueteId { get; set; }
        public int OrdemPergunta { get; set; }

        [StringLength(200)]
        public string? Pergunta { get; set; }
        public string? Resposta { get; set; }
        public int PessoaId { get; set; }
    }
}
