using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representa o vendedor ou ponto de venda
	/// </summary>
	public class Merchant
	{
		/// <summary>
		/// O merchant id do vendedor
		/// </summary>
		public String id { get; set; }

		/// <summary>
		/// A chave de integração do vendedor
		/// </summary>
		public String key { get; set; }

		/// <summary>
		/// Cria uma instância de Cielo.Merchant definindo o merchant id e merchant key
		/// </summary>
		/// <param name="id">O merchant id do vendedor</param>
		/// <param name="key">A chave de integração do vendedor</param>
		public Merchant (String id, String key)
		{
			this.id = id;
			this.key = key;
		}
	}
}