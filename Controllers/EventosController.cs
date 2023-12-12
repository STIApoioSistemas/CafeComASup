using CafeComASup.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeComASup.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //feVM = funcionario evento View Model
        public IActionResult Cafe(FuncionarioEventoVM feVM)
        {
            return View(feVM);
        }
    }
}
