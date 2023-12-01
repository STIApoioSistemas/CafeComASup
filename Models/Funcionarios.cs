using System.ComponentModel.DataAnnotations;

namespace CafeComASup.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Prontuario { get; set; }

        public string? Email { get; set; }
    }
}
