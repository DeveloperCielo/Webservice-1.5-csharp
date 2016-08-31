using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representa os dados de uma autorização
	/// </summary>
	public class Authorization
	{
		/// <summary>
		/// O código da autorização
		/// </summary>
		public int code { get; set; }

		/// <summary>
		/// A mensagem da autorização
		/// </summary>
		public String message { get; set; }

		/// <summary>
		/// A data e hora da autorização
		/// </summary>
		public String dateTime { get; set; }

		/// <summary>
		/// O total autorizado
		/// </summary>
		public int total { get; set; }

		/// <summary>
		/// O código LR da autorização
		/// </summary>
		public string lr { get; set; }

		/// <summary>
		/// O código ARP da autorização
		/// </summary>
		public string arp { get; set; }

		/// <summary>
		/// O código NSU da autorização
		/// </summary>
		public int nsu { get; set; }
	}
}