using CafeComASup.Models;

namespace CafeComASup.Mail

{
	public class Email
	{
		public static void EnvioDoEmail(Eventos e, Funcionarios f, Confirmados c)
		{
			//HelperMensagem.RetornarPagina() é a função que cria o corpo do email, HTML mesmo
			var corpo = HelperMensagem.RetornarPagina(e, f, c);

			//HelperMensagem.RetornarEmail() cria o email que a API do Lucas espera
			var email = HelperMensagem.RetornarEmail(f.Email, "Balanço Institucional 2023 e Perspectivas Futuras", corpo);

			//Aqui o email é enviado
			_ = ApiEmail.EnviarEmail(email);
		}
		
	}
}
