namespace CafeComASup.Models
{
    public class FuncionarioEventoVM
    {   
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Data { get; set; }
		public string? Horario { get; set; }

        public int Vagas { get; set; }
        public DateTime? DataConfirmacao { get; set; }
        public string? Protocolo { get; set; }
    }
}
