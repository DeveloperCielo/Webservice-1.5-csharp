using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representa um token do cartão do cliente para que possa ser armazenado
	/// de forma segura para novas compras do mesmo cliente no futuro.
	/// </summary>
	public class Token
	{
		/// <summary>
		/// O TOKEN retornado pela Cielo
		/// </summary>
		public String code { get; set; }

		/// <summary>
		/// Status do token
		/// </summary>
		public int status { get; set; }

		/// <summary>
		/// Número do cartão truncado
		/// </summary>
		public String number { get; set; }
	}
}