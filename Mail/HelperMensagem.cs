using CafeComASup.Models;

namespace CafeComASup.Mail
{
	public class HelperMensagem
	{
		public static EmailViewModel RetornarEmail(string? destinatario, string? assunto, string? msg)
		{
			return new EmailViewModel()
			{
				Remetente = "Balanço Institucional 2023 e Perspectivas Futuras",
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

					$"<p style=\"text-align: center;\"> Você está confirmado(a) no <strong>Balanço Institucional 2023</strong></p>" +

					$"<p style=\"text-align: center;\"> DATA:<strong> 12 DE DEZEMBRO DE 2023</strong></p>" +

					$"<p style=\"text-align: center;\"> HORÁRIO:<strong>DAS 10H30 ÀS 14H30</strong></p>" +

					$"<p style=\"text-align: center;\"> LOCAL:<strong>AUDITÓRIO AUGUSTO RUSCHI</strong></p>" +

					$"<p style=\"text-align: center;\"> AV. PROF. FREDERICO HERMANN JUNIOR, 345</p>" +

					$"<p style=\"text-align: center;\"> (PRÓXIMO AO METRÔ PINHEIROS)</p>" +

					$"<p style=\"text-align: center;\"> OBSERVAÇÃO:<strong>NÃO HÁ ESTACIONAMENTO NO LOCAL</strong></p>" +

					$"<p style=\"text-align: center;\">Data e Hora: <strong>{c.DataConfirmacao}</strong></p>" +
					
					$"<p style=\"text-align: center;\">Número do Protocolo: <strong>{c.Protocolo}</strong></p>" +
					$"<p style=\"text-align: center;\">*Por gentileza, caso haja desistência, entre em contato no email: imprensadaee@sp.gov.br até 11/12/2023 </p>";
		}
	}
}
