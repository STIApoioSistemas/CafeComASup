using CafeComASup.Models;

namespace CafeComASup.Repository
{
    public interface ICafeRepository
    {
        Funcionarios? GetFuncionario(Funcionarios? func);
        int? GetCountConfirmed();

        Confirmados? GetIsEmailConfirmed(int id);

        Eventos GetEvento(int id);

        Confirmados? InsertFuncionario(Eventos e, Funcionarios f);
		bool InsertFuncionarioReserva(Eventos e, Funcionarios f);

		public FuncionarioEventoVM? GetFuncionarioEvento(Eventos e, Funcionarios f);

        public FuncionarioEventoVM? GetProtocolo(FuncionarioEventoVM? funcionarioEvento);
    }
}