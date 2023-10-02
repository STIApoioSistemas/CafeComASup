using CafeComASup.Models;

namespace CafeComASup.Mail

{
	public class Email
	{
		public static void EnvioDoEmail(Eventos e, Funcionarios f, Confirmados c)
		{
			var corpo = HelperMensagem.RetornarPagina(e, f, c);
			var email = HelperMensagem.RetornarEmail(f.Email, "Café com a Superintendente", corpo);
			_ = ApiEmail.EnviarEmail(email);
		}
		
	}
}
