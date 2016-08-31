using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representa o meio de pagamento escolhido pelo cliente
	/// </summary>
	public class PaymentMethod
	{
		/// <summary>
		/// Cartão VISA
		/// </summary>
		public const String VISA = "visa";
		/// <summary>
		/// Cartão Mastercard
		/// </summary>
		public const String MASTERCARD = "mastercard";
		/// <summary>
		/// Cartão Diners
		/// </summary>
		public const String DINERS = "diners";
		/// <summary>
		/// Cartão Discover
		/// </summary>
		public const String DISCOVER = "discover";
		/// <summary>
		/// Cartão ELO
		/// </summary>
		public const String ELO = "elo";
		/// <summary>
		/// Cartão AMES
		/// </summary>
		public const String AMEX = "amex";
		/// <summary>
		/// Cartão JCB
		/// </summary>
		public const String JCB = "jcb";
		/// <summary>
		/// Cartão AURA
		/// </summary>
		public const String AURA = "aura";

		/// <summary>
		/// Para transações em crédito a vista
		/// </summary>
		public const String CREDITO_A_VISTA = "1";
		/// <summary>
		/// Para transações parceladas pela loja
		/// </summary>
		public const String PARCELADO_LOJA = "2";
		/// <summary>
		/// Para transações parceladas pela administradora
		/// </summary>
		public const String PARCELADO_ADM = "3";
		/// <summary>
		/// Para transações em débito
		/// </summary>
		public const String DEBITO = "A";

		/// <summary>
		/// Emissor do cartão
		/// </summary>
		/// <value>The issuer.</value>
		public String issuer { get; set; }

		/// <summary>
		/// Produto utilizado; crédito, débito, parcelado
		/// </summary>
		public String product { get; set; }

		/// <summary>
		/// Número de parcelas
		/// </summary>
		public int installments { get; set; }

		/// <summary>
		/// Cria uma instância de Cielo.PaymentMethod definindo o emissor do cartão.
		/// </summary>
		/// <param name="issuer">Emissor do cartão</param>
		public PaymentMethod (String issuer)
		{
			this.issuer = issuer;
		}

		/// <summary>
		/// Cria uma instância de Cielo.PaymentMethod definindo o emissor do cartão
		/// e o produto utilizado.
		/// </summary>
		/// <param name="issuer">Emissor do cartão</param>
		/// <param name="product">O produto utilizado; crédito, débito, parcelado.</param>
		public PaymentMethod (String issuer, String product)
			: this (issuer)
		{
			this.product = product;
			this.installments = 1;
		}

		/// <summary>
		/// Cria uma instância de Cielo.PaymentMethod definindo o emissor do cartão, 
		/// o produto utilizado e o número de parcelas.
		/// </summary>
		/// <param name="issuer">Emissor do cartão</param>
		/// <param name="product">O produto utilizado; crédito, débito, parcelado.</param>
		/// <param name="installments">Número de parcelas</param>
		public PaymentMethod (String issuer, String product, int installments)
			: this (issuer, product)
		{
			this.installments = installments;
		}
	}
}