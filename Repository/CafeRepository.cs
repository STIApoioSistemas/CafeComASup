using CafeComASup.Contexto;
using CafeComASup.Models;


namespace CafeComASup.Repository
{
    public class CafeRepository : ICafeRepository
    {
        #region DECLARE
        private readonly Context _Context;
        #endregion

        #region CONSTRUCTOR
        public CafeRepository(Context context)
        {
            _Context = context;
        }
        #endregion

        #region GET
        public Funcionarios? GetFuncionario(Funcionarios? func)
        {   
            var funcionario = _Context.Funcionarios?.FirstOrDefault(f => f.Email == func.Email);

            if (funcionario != null) return funcionario;
            return null;
        }

        public int? GetCountConfirmed() {
            var cont = _Context.Confirmados?.Count();
            return cont;
        }

        public Confirmados? GetIsEmailConfirmed(int id)
        {
            return _Context.Confirmados?.FirstOrDefault(f => f.PessoaId == id);
        }

        public Eventos? GetEvento(int id)
        {
            var evento = _Context.Eventos?.FirstOrDefault(e => e.Id == id);
            return evento;
        }

        public FuncionarioEventoVM? GetFuncionarioEvento(Eventos? e, Funcionarios f)
        {
            FuncionarioEventoVM dados = new()
            {   Id = f.Id,
                Nome = f.Nome,
                Titulo = e.Titulo,
                Descricao = e.Descricao,
                Vagas = e.Vagas,
                Data = e.DataEvento.ToString("dd/MM/yyyy"),
				Horario = e.DataEvento.ToString("HH:mm"),
            };

            return dados;
        }

		public FuncionarioEventoVM? GetProtocolo(FuncionarioEventoVM funcionarioEvento)
        {
            Confirmados? confirmado = _Context.Confirmados?.FirstOrDefault(p => p.PessoaId == funcionarioEvento.Id);
            funcionarioEvento.Protocolo = confirmado?.Protocolo;
            funcionarioEvento.DataConfirmacao = confirmado?.DataConfirmacao;
			return funcionarioEvento;
        }
		#endregion

		#region INSERT
		public Confirmados? InsertFuncionario(Eventos? e, Funcionarios f)
        {
            Confirmados conf;
 
            try
            {
                 conf = new()
                {
                    EventoId = e.Id,
                    PessoaId = f.Id,
                    Protocolo = DateTime.Now.ToString("yyyyMMddHHmmss"),
					DataConfirmacao = DateTime.Now,
                    DataEnvioEmail = DateTime.Now,
                };

                _Context.Confirmados?.Add(conf);
                _Context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

			return conf;
        }

		public bool InsertFuncionarioReserva(Eventos? e, Funcionarios f)
		{
			try
			{
	            Reservas reserva = new()
	            {
                    EventoId = e.Id,
		            PessoaId = f.Id,
					Protocolo = DateTime.Now.ToString("yyyyMMddHHmmss"),
					DataConfirmacao = DateTime.Today,
	            };

				_Context.Reservas?.Add(reserva);
				_Context.SaveChanges();
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		#endregion
	}
}
