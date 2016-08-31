using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representa um pedido que a loja enviará para autorização na Cielo
	/// </summary>
	public class Order
	{
		/// <summary>
		/// Número único do pedido
		/// </summary>
		public String number { get; set; }

		/// <summary>
		/// Total do pedido em centavos
		/// </summary>
		public int total { get; set; }

		/// <summary>
		/// Moeda do pedido - 986 para BRL é o padrão
		/// </summary>
		public int currency { get; set; }

		/// <summary>
		/// Data e hora do pedido - a hora atual é o padrão
		/// </summary>
		public String dateTime { get; set; }

		/// <summary>
		/// Descrição do pedido
		/// </summary>
		public String description { get; set; }

		/// <summary>
		/// Idioma do pedido - PT é o padrão.
		/// </summary>
		public String language { get; set; }

		/// <summary>
		/// Total do frete e despespesas de entrega em centavos
		/// </summary>
		public int shipping { get; set; }

		/// <summary>
		/// Softdescriptor que aparecerá na fatura do cartão do cliente
		/// </summary>
		public String softDescriptor { get; set; }

		/// <summary>
		/// Cria uma instância de Cielo.Order definindo o número do pedido e seu total. A
		/// moeda, data e hora e idioma serão definidos em seus padrões.
		/// </summary>
		/// <param name="number">Número do pedido</param>
		/// <param name="total">Total do pedido em centavos</param>
		public Order (String number, int total)
		{
			this.number = number;
			this.total = total;
			this.currency = 986; //BRL
			this.dateTime = DateTime.Now.ToString ("yyy-MM-ddTHH:mm:ss");
			this.description = "";
			this.language = "PT";
		}

		/// <summary>
		/// Cria uma instância de Cielo.Order definindo o número do pedido, total e a moeda. A
		/// data e hora e idioma serão definidos em seus padrões.
		/// </summary>
		/// <param name="number">Número do pedido</param>
		/// <param name="total">Total do pedido em centavos</param>
		/// <param name="currency">Moeda do pedido</param>
		public Order (String number, int total, int currency)
			: this (number, total)
		{
			this.currency = currency;
		}

		/// <summary>
		/// Cria uma instância de Cielo.Order definindo o número do pedido, total e data e hora. A
		/// moeda e idioma serão definidos em seus padrões.
		/// </summary>
		/// <param name="number">Número do pedido</param>
		/// <param name="total">Total do pedido em centavos</param>
		/// <param name="dateTime">Data e hora do pedido</param>
		public Order (String number, int total, String dateTime)
			: this (number, total)
		{
			this.dateTime = dateTime;
		}

		/// <summary>
		/// Cria uma instância de Cielo.Order definindo os dados do pedido.
		/// </summary>
		/// <param name="number">Número do pedido</param>
		/// <param name="total">Total do pedido em centavos</param>
		/// <param name="dateTime">Data e hora do pedido</param>
		/// <param name="currency">Moeda do pedido</param>
		public Order (String number, int total, String dateTime, int currency)
			: this (number, total, dateTime)
		{
			this.currency = currency;
		}
	}
}