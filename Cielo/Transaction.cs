using System;

namespace CieloEcommerce
{
	/// <summary>
	/// Representação de uma transação
	/// </summary>
	public class Transaction
	{
		/// <summary>
		/// Métodos de autorização possíveis
		/// </summary>
		public enum AuthorizationMethod
		{
			/// <summary>
			/// Apenas autenticação
			/// </summary>
			ONLY_AUTHENTICATE = 0,

			/// <summary>
			/// Autoriza se for autenticado
			/// </summary>
			AUTHORIZE_IF_AUTHENTICATED = 1,

			/// <summary>
			/// Apenas autoriza
			/// </summary>
			AUTHORIZE = 2,

			/// <summary>
			/// Autorização direta
			/// </summary>
			AUTHORIZE_WITHOUT_AUTHENTICATION = 3,

			/// <summary>
			/// Recorrência
			/// </summary>
			RECURRENCE = 4
		}

		/// <summary>
		/// Identificador da transação
		/// </summary>
		/// <value>The tid.</value>
		public String tid { get; set; }

		/// <summary>
		/// PAN da transação
		/// </summary>
		/// <value>The pan.</value>
		public String pan { get; set; }

		/// <summary>
		/// status da transação
		/// </summary>
		/// <value>The status.</value>
		public int status { get; set; }

		/// <summary>
		/// URL de autenticação em caso de transações de débito
		/// </summary>
		/// <value>The authentication URL.</value>
		public String authenticationUrl { get; set; }

		/// <summary>
		/// Detalhes da autorização
		/// </summary>
		/// <value>The authorization.</value>
		public Authorization authorization { get; set; }

		/// <summary>
		/// Detalhes da autenticação
		/// </summary>
		/// <value>The authentication.</value>
		public Authentication authentication { get; set; }

		/// <summary>
		/// Detalhes do estabelecimento comercial
		/// </summary>
		/// <value>The merchant.</value>
		public Merchant merchant { get; set; }

		/// <summary>
		/// Detalhes do portador do cartão
		/// </summary>
		/// <value>The holder.</value>
		public Holder holder { get; set; }

		/// <summary>
		/// Detalhes do pedido
		/// </summary>
		/// <value>The order.</value>
		public Order order { get; set; }

		/// <summary>
		/// Forma de pagamento
		/// </summary>
		/// <value>The payment method.</value>
		public PaymentMethod paymentMethod { get; set; }

		/// <summary>
		/// URL de retorno
		/// </summary>
		/// <value>The return UR.</value>
		public String returnURL { get; set; }

		/// <summary>
		/// Método utilizado para autorização. Veja Cielo.Transaction.AuthorizationMethod
		/// </summary>
		/// <value>The authorize.</value>
		public AuthorizationMethod authorize { get; set; }

		/// <summary>
		/// Determina se a transação será capturada automaticamente ou de forma manual
		/// </summary>
		/// <value><c>true</c> if capture; otherwise, <c>false</c>.</value>
		public bool capture { get; set; }

		/// <summary>
		/// Campo livre
		/// </summary>
		/// <value>The free field.</value>
		public String freeField { get; set; }

		/// <summary>
		/// Primeiros 6 dígitos do cartão
		/// </summary>
		/// <value>The bin.</value>
		public String bin { get; set; }

		/// <summary>
		/// Determina se deverá ser gerado um token para o cartão
		/// </summary>
		public bool generateToken;

		/// <summary>
		/// AVS
		/// </summary>
		/// <value>The AV.</value>
		public String AVS { get; set; }

		/// <summary>
		/// Detalhes do token
		/// </summary>
		/// <value>The token.</value>
		public Token token { get; set; }


		/// <param name="merchant">Detalhes do estabelecimento comercial</param>
		/// <param name="holder">Detalhes do portador do cartão</param>
		/// <param name="order">Detalhes do pedido</param>
		/// <param name="paymentMethod">Forma de pagamento</param>
		/// <param name="returnURL">URL de retorno</param>
		/// <param name="authorize">Método de autorização</param>
		/// <param name="capture">Determina se a transação deverá ser capturada automaticamente</param>
		public Transaction (
			Merchant merchant,
			Holder holder,
			Order order,
			PaymentMethod paymentMethod,
			String returnURL,
			AuthorizationMethod authorize,
			bool capture)
		{
			this.merchant = merchant;
			this.holder = holder;
			this.order = order;
			this.paymentMethod = paymentMethod;
			this.returnURL = returnURL;
			this.authorize = authorize;
			this.capture = capture;
		}

        public Transaction()
        {
            
        }
	}
}