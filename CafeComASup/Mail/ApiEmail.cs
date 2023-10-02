using CafeComASup.Models;
using System.Net.Http.Headers;
using System.Net;

namespace CafeComASup.Mail
{
	public class ApiEmail
	{
		public static async Task<HttpStatusCode> EnviarEmail(EmailViewModel email)
		{
			try
			{
				var client = new HttpClient();
				//client.BaseAddress = new Uri("http://10.20.42.3:5001/");
				client.BaseAddress = new Uri("http://localhost:5001/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = await client.PostAsJsonAsync($"v1/Email?hash={Parametros.HashEmail}", email);
				return response.StatusCode;
			}
			catch
			{
				return HttpStatusCode.ExpectationFailed;
			}
		}
	}
}
