using CafeComASup.Mail;
using CafeComASup.Models;
using CafeComASup.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CafeComASup.Controllers
{
    public class CafeSupController : Controller
    {
        #region DECLARE
        private readonly ILogger<CafeSupController> _logger;
        private readonly ICafeRepository _CafeRepository;
        #endregion

        #region CONSTRUCTOR
        public CafeSupController(ILogger<CafeSupController> logger, ICafeRepository cafeRepository)
        {
            _logger = logger;
            _CafeRepository = cafeRepository;
        }
		#endregion

		#region POST
		
		[HttpPost]
		public IActionResult Index(Funcionarios func)
		{	
			var funcionario = _CafeRepository.GetFuncionario(func);
			var evento = _CafeRepository.GetEvento(3);

			//Checa se encontrou o funcionario na variavel acima
			if (funcionario != null)
			{
				//dados é uma variavel que traz informações tanto do evento quanto do funcionario
				//serve principalmente para preencher a ViewModel
				FuncionarioEventoVM? dados = _CafeRepository.GetFuncionarioEvento(evento, funcionario);

				//GetConfimedCount() é uma função que faz uma pesquisa por meio do Repository para
				//saber quantos confirmados já possuem nesse evento e rola essa comparação ai com o 
				//evento que foi achado na variavel la em cima
				if (GetConfirmedCount() < evento.Vagas)
				{

					/*
					IsEmailConfirmed() é uma função que vai checar se esse funcionario.Id já está
					dentro dos confirmados, se ele estiver (retornar true) o sinal de ! vai transformar
					true em false e não vamos entrar nesse if, se ele não estiver nos confirmados, irá 
					retornar false e o ! vai transformar em true, então vamos entrar dentro desse if.
					 */
					if (!IsEmailConfirmed(funcionario.Id))
					{	
						//Insere o funcionario em confirmados
						Confirmados? conf = _CafeRepository.InsertFuncionario(evento, funcionario);

						//Api do Lucas para enviar o email
						Email.EnvioDoEmail(evento, funcionario, conf);

						//Etapa que serve apenas para mandar os dados e colocar dentro dele o numero
						//de protocolo
						dados = _CafeRepository.GetProtocolo(dados);

						//Tela de "sucesso"
						return RedirectToAction("Cafe", "Eventos", dados);
					}
				}

				/*
				IsEmailConfirmed() aparece aqui de novo porque vai ter vezes que o if aqui em cima não
				irá ser acessado, então checamos aqui para ver se o email está no confirmados, porque o 
				email não pode estar no confirmados e no reservas ao mesmo tempo (esse if insere no reservas)
				*/
				if (!IsEmailConfirmed(funcionario.Id))
				{
					//Insere o funcionario em reservas
					_CafeRepository.InsertFuncionarioReserva(evento, funcionario);

					//Tela de erro que informa vagas esgotadas
					return View("Error", "Erro01");
				}

				//Etapa que serve apenas para mandar os dados e colocar dentro dele o numero de protocolo
				dados = _CafeRepository.GetProtocolo(dados);

				//Tela de "sucesso"
				return RedirectToAction("Cafe", "Eventos", dados);
			}

			//Erro que aparece caso nao encontre o funcionario
			return View("Error", "Erro02");
		}
		#endregion

		#region GET
		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Error()
		{
			return View();
		}
		#endregion

		#region FUNCTION

		private int? GetConfirmedCount()
        {
            return _CafeRepository.GetCountConfirmed();
        }

        private bool IsEmailConfirmed(int id)
        {
            var resp = _CafeRepository.GetIsEmailConfirmed(id);
            if(resp == null) return false;
            return true;
        }
        #endregion

    }
}