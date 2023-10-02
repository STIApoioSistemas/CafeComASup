using CafeComASup.Models;

namespace CafeComASup.Mail
{
	public class HelperMensagem
	{
		public static EmailViewModel RetornarEmail(string? destinatario, string? assunto, string? msg)
		{
			return new EmailViewModel()
			{
				Remetente = "Café com a Superintendente",
				Destinatario = destinatario,
				Assunto = assunto,
				Mensagem = msg,
			};
		}

		public static string RetornarPagina(Eventos e, Funcionarios f, Confirmados c)
		{
			return $"<p style=\"text-align: center;\"><i>{e.Descricao}</i></p>" +
					$"<br/>" +
					$"<p style=\"text-align: center;\">Olá, <strong>{f.Nome}!</strong></p>" +
					$"<p style=\"text-align: center;\"> Você está confirmado(a) no <strong>Café com a Superintendente</strong></p>" +
					$"<p style=\"text-align: center;\">Data: <strong>{e.DataEvento.ToString("dd/MM/yyyy")}</strong></p>" +
					$"<p style=\"text-align: center;\">Horário: <strong>{e.DataEvento.ToString("HH:mm")}</strong></p>" +
					$"<br />" +
					$"<p style=\"text-align: center;\">Protocolo: <strong>{c.Protocolo}</strong></p>" +
					$"<p style=\"text-align: center;\">*Caso não possa comparecer na data, por favor informar a equipe da comunicação em até 48h antes do evento. </p>";
					
		}
	}
}
