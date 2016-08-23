using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representa os dados de uma autenticação
	/// </summary>
	public class Authentication
	{
		/// <summary>
		/// Código da autenticação
		/// </summary>
		public int code { get; set; }

		/// <summary>
		/// Mensagem da autenticação
		/// </summary>
		public String message { get; set; }

		/// <summary>
		/// Data e hora da autenticação
		/// </summary>
		public String dateTime { get; set; }

		/// <summary>
		/// O total autenticado pelo cliente
		/// </summary>
		public int total { get; set; }

		/// <summary>
		/// O código ECI da autenticação
		/// </summary>
		public int eci { get; set; }
	}
}