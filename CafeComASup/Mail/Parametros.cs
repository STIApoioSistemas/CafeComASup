using System.Security.Cryptography;
using System.Text;

namespace CafeComASup.Mail
{
	public static class Parametros
    {
        public const string VersaoAPIEmail = "1.0.0";

		//VersaoAPIEmail_ANO_MES_1
		//272e905b9e72ec96d3f574e7feeaa74
		public static string GerarMD5(string input)
		{
			MD5 md5Hash = MD5.Create();
			byte[] criptografado = md5Hash.ComputeHash(Encoding.Default.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < criptografado.Length; i++)
				stringBuilder.Append(criptografado[i].ToString("x2"));

			return stringBuilder.ToString();
		}

		public static string HashEmail = GerarMD5($"{VersaoAPIEmail}_{new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)}");
    }
}
