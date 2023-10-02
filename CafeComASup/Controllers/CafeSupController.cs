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
			var evento = _CafeRepository.GetEvento(1);

			if (funcionario != null)
			{
				FuncionarioEventoVM? dados = _CafeRepository.GetFuncionarioEvento(evento, funcionario);

				if (GetConfirmedCount() < evento.Vagas)
				{
					if (!IsEmailConfirmed(funcionario.Id))
					{
						Confirmados? conf = _CafeRepository.InsertFuncionario(evento, funcionario);
						Email.EnvioDoEmail(evento, funcionario, conf);
						dados = _CafeRepository.GetProtocolo(dados);

						return RedirectToAction("Cafe", "Eventos", dados);
					}
				}

				if (!IsEmailConfirmed(funcionario.Id))
				{
					_CafeRepository.InsertFuncionarioReserva(evento, funcionario);
					return View("Error", "Erro01");
				}

				dados = _CafeRepository.GetProtocolo(dados);
				return RedirectToAction("Cafe", "Eventos", dados);
			}
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