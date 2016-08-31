using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representação do portador de um cartão
	/// </summary>
	public class Holder
	{
		/// <summary>
		/// Detalhe sobre o código CVV do cartão
		/// </summary>
		public enum CVV
		{
			/// <summary>
			/// O CVV não foi informado
			/// </summary>
			NOT_INFORMED = 0,

			/// <summary>
			/// O CVV foi informado
			/// </summary>
			INFORMED = 1,

			/// <summary>
			/// O CVV não estava legível
			/// </summary>
			UNREADABLE = 2,

			/// <summary>
			/// Não havia um CVV
			/// </summary>
			NONEXISTENT = 9,
		}

		/// <summary>
		/// Número do cartão
		/// </summary>
		public String number { get; set; }

		/// <summary>
		/// Data de expiração do cartão
		/// </summary>
		public String expiration { get; set; }

		/// <summary>
		/// Indicador sobre o código CVV do cartão; veja Cielo.Holder.CVV
		/// </summary>
		public CVV indicator { get; set; }

		/// <summary>
		/// O CVV do cartão
		/// </summary>
		public String cvv { get; set; }

		/// <summary>
		/// O nome do portador
		/// </summary>
		public String name { get; set; }

		/// <summary>
		/// Token do cartão, caso tenha sido gerado previamente.
		/// </summary>
		public String token { get; set; }

		/// <summary>
		/// Cria uma instância de Cielo.Holder definindo o token do cartão
		/// </summary>
		/// <param name="token">Token gerado previamente</param>
		public Holder (String token)
		{
			this.token = token;
		}

		/// <summary>
		/// Cria uma instância de Cielo.Holder definindo os dados do cartão. O
		/// indicador será definido automaticamente como CVV.INFORMED.
		/// </summary>
		/// <param name="number">Número do cartão</param>
		/// <param name="expirationYear">Ano de expiração do cartão</param>
		/// <param name="expirationMonth">Mês de expiração do cartão</param>
		/// <param name="cvv">CVV do cartão</param>
		public Holder (String number, String expirationYear, String expirationMonth, String cvv)
		{
			this.number = number;
			this.expiration = expirationYear + expirationMonth;
			this.cvv = cvv;
			this.indicator = CVV.INFORMED;

		}

		/// <summary>
		/// Cria uma instância de Cielo.Holder definindo os dados do cartão.
		/// </summary>
		/// <param name="number">Número do cartão</param>
		/// <param name="expirationYear">Ano de expiração do cartão</param>
		/// <param name="expirationMonth">Mês de expiração do cartão</param>
		/// <param name="cvv">CVV do cartão</param>
		/// <param name="indicator">Indicador do CVV do cartão; ; veja Cielo.Holder.CVV</param>
		public Holder (String number, String expirationYear, String expirationMonth, String cvv, CVV indicator)
			: this (number, expirationYear, expirationMonth, cvv)
		{
			this.indicator = indicator;
		}
	}
}