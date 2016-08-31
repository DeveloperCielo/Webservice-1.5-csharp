using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CieloEcommerce.Request;
using CieloEcommerce.Request.Element;

namespace CieloEcommerce
{
	/// <summary>
	/// Integração com o Webservice 1.5 da Cielo; esse participante faz um
	/// papel de facilitador para a construção de todos os participantes
	/// importantes para a integração. Através de factory methods, é possível
	/// criar as instâncias pré-configuradas com os parâmetros mínimos necessários
	/// para a execução das operações.
	/// </summary>
	public class Cielo
	{
		/// <summary>
		/// Versão interna do webservice
		/// </summary>
		public const String VERSION = "1.3.0";

		/// <summary>
		/// Endpoint de produção
		/// </summary>
		public const String PRODUCTION = "https://ecommerce.cielo.com.br/servicos/ecommwsec.do";
		/// <summary>
		/// Endpoint de testes
		/// </summary>
		public const String TEST = "https://qasecommerce.cielo.com.br/servicos/ecommwsec.do";

		private Merchant merchant;

		private String endpoint = PRODUCTION;

		/// <summary>
		/// Constroi a instância de Cielo definindo o Merchant ID, Merchant Key e
		/// o endpoint para onde serão enviadas as requisições
		/// </summary>
		/// <param name="id">Identifier.</param>
		/// <param name="key">Key.</param>
		/// <param name="endpoint">Endpoint.</param>
		public Cielo (String id, String key, String endpoint = PRODUCTION)
		{
			this.merchant = new Merchant (id, key);
			this.endpoint = endpoint;
		}

		/// <summary>
		/// Cria uma instância de Cielo.Holder, que representa o portador de um cartão,
		/// apenas definindo o token previamente gerado.
		/// </summary>
		/// <param name="token">Token.</param>
		public Holder holder (String token)
		{
			return new Holder (token);
		}

		/// <summary>
		/// Cria uma instância de Cielo.Holder, que representa o portador de um cartão,
		/// apenas definindo o número do cartão, ano e mês de expiração, código de segurança e
		/// o indicador do código de segurança.
		/// </summary>
		/// <param name="number">Número do cartão</param>
		/// <param name="expirationYear">Ano de expiração</param>
		/// <param name="expirationMonth">Mês de expiração</param>
		/// <param name="cvv">CVV - Código de segurança do verso do cartão</param>
		/// <param name="indicator">Indicador de segurança; veja Cielo.Holder.CVV</param>
		public Holder holder (
			String number,
			String expirationYear,
			String expirationMonth,
			String cvv,
			Holder.CVV indicator = Holder.CVV.INFORMED)
		{
			return new Holder (number, expirationYear, expirationMonth, cvv, indicator);
		}

		/// <summary>
		/// Cria uma instância de Cielo.Order, que representa os dados do pedido,
		/// definindo o número do pedido, valor total do pedido, data do pedido e moeda.
		/// </summary>
		/// <param name="number">Número do pedido</param>
		/// <param name="total">Total do pedido</param>
		/// <param name="dateTime">Data e hora do pedido</param>
		/// <param name="currency">Moeda do pedido - 986 para BRL</param>
		public Order order (String number, int total, String dateTime, int currency)
		{
			return new Order (number, total, dateTime, currency);
		}

		/// <summary>
		/// Cria uma instância de Cielo.Order, que representa os dados do pedido,
		/// definindo o número do pedido, valor total do pedido, data do pedido. A moeda será
		/// configurada por padrâo para 986 - BRL.
		/// </summary>
		/// <param name="number">Número do pedido</param>
		/// <param name="total">Total do pedido</param>
		/// <param name="dateTime">Data e hora do pedido</param>
		public Order order (String number, int total, String dateTime)
		{
			return new Order (number, total, dateTime);
		}

		/// <summary>
		/// Cria uma instância de Cielo.Order, que representa os dados do pedido,
		/// definindo o número do pedido e valor total. A data será configurada como a data
		/// atual e a moeda será configurada por padrâo para 986 - BRL.
		/// </summary>
		/// <param name="number">Número do pedido</param>
		/// <param name="total">Total do pedido</param>
		public Order order (String number, int total)
		{
			return new Order (number, total);
		}

		/// <summary>
		/// Cria uma instância de Cielo.PaymentMethod, que representa a forma de pagamento,
		/// definindo o emissor do cartão.
		/// </summary>
		/// <param name="issuer">O emissor do cartão - VISA, MASTERCARD, AMEX, etc</param>
		public PaymentMethod paymentMethod (String issuer)
		{
			return new PaymentMethod (issuer);
		}

		/// <summary>
		/// Cria uma instância de Cielo.PaymentMethod, que representa a forma de pagamento,
		/// definindo o emissor do cartão e o produto Cielo utilizado.
		/// </summary>
		/// <param name="issuer">O emissor do cartão - VISA, MASTERCARD, AMEX, etc</param>
		/// <param name="product">O produto utilizado na transação - crédito, débito, parcelado, etc</param>
		public PaymentMethod paymentMethod (String issuer, String product)
		{
			return new PaymentMethod (issuer, product);
		}

		/// <summary>
		/// Cria uma instância de Cielo.PaymentMethod, que representa a forma de pagamento,
		/// definindo o emissor do cartão, o produto Cielo utilizado e o número de parcelas.
		/// </summary>
		/// <param name="issuer">O emissor do cartão - VISA, MASTERCARD, AMEX, etc</param>
		/// <param name="product">O produto utilizado na transação - crédito, débito, parcelado, etc</param>
		/// <param name="installments">Quantidade de parcelas</param>
		public PaymentMethod paymentMethod (String issuer, String product, int installments)
		{
			return new PaymentMethod (issuer, product, installments);
		}

		/// <summary>
		/// Cria uma instância de Transaction pré-configurada
		/// </summary>
		/// <param name="holder">Detalhes do portador do cartão</param>
		/// <param name="order">Detalhes do pedido</param>
		/// <param name="paymentMethod">Forma de pagamento</param>
		/// <param name="returnURL">URL de retorno</param>
		/// <param name="authorize">Método de autorização</param>
		/// <param name="capture">Determina se a transação deverá ser capturada automaticamente</param>
		/// <returns>>Uma instância de Transaction</returns>
		public Transaction transaction (
			Holder holder,
			Order order,
			PaymentMethod paymentMethod,
			String returnURL,
			Transaction.AuthorizationMethod authorize,
			bool capture)
		{
			return new Transaction (merchant, holder, order, paymentMethod, returnURL, authorize, capture);
		}

		String sendHttpRequest (String message)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (endpoint);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			using (Stream stream = request.GetRequestStream ()) {
				UTF8Encoding encoding = new UTF8Encoding ();
				byte[] bytes = encoding.GetBytes ("mensagem=" + message);

				stream.Write (bytes, 0, bytes.Length);
			}

			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			string result;

			using (Stream stream = response.GetResponseStream ()) {
				using (StreamReader reader = new StreamReader (stream, Encoding.UTF8)) {
					result = reader.ReadToEnd ();
				}
			}

			return result.ToString ();
		}

		String serialize<T> (T request)
		{
			XmlSerializer xmlserializer = new XmlSerializer (typeof(T));
			StringWriter stringWriter = new StringWriter ();

			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings {
				Indent = true,
				OmitXmlDeclaration = true,
				Encoding = Encoding.GetEncoding ("ISO-8859-1")
			};

			XmlWriter xmlWriter = XmlWriter.Create (stringWriter, xmlWriterSettings);

			xmlserializer.Serialize (xmlWriter, request);

			return stringWriter.ToString ();
		}

		/// <summary>
		/// Cria uma transação com os dados informados e envia uma requisição-autorizacao-tid para
		/// o webservice Cielo.
		/// </summary>
		/// <returns>A transação retornada pela Cielo e seu respectivo status</returns>
		/// <param name="holder">Portador do cartão</param>
		/// <param name="order">Dados do pedido</param>
		/// <param name="paymentMethod">Método de pagamento</param>
		/// <param name="returnURL">URL de retorno</param>
		/// <param name="authorize">Método de autorização</param>
		/// <param name="capture">Define se a transação deve ser capturada automaticamente</param>
		public Transaction authorizationRequest (
			Holder holder,
			Order order,
			PaymentMethod paymentMethod,
			String returnURL,
			Transaction.AuthorizationMethod authorize,
			bool capture)
		{
			return authorizationRequest (transaction (holder, order, paymentMethod, returnURL, authorize, capture));
		}

		/// <summary>
		/// Envia uma requisição-autorizacao-tid para o webservice Cielo para que a transação
		/// seja autorizada segundo as configurações previamente feitas.
		/// </summary>
		/// <returns>A transação retornada pela Cielo e seu respectivo status</returns>
		/// <param name="transaction">A transação previamente configurada</param>
		public Transaction authorizationRequest (Transaction transaction)
		{
			AuthorizationRequest request = AuthorizationRequest.create (transaction);
			return TransacaoElement.unserialize (transaction, sendHttpRequest (serialize (request)));
		}

		/// <summary>
		/// Envia uma requisição-cancelamento para o webservice Cielo para cancelar uma transação
		/// </summary>
		/// <returns>A transação com o respectivo status retornada pela Cielo</returns>
		/// <param name="holder">Portador do cartão</param>
		/// <param name="order">Dados do pedido</param>
		/// <param name="paymentMethod">Método de pagamento</param>
		/// <param name="returnURL">URL de retorno</param>
		/// <param name="authorize">Método de autorização</param>
		/// <param name="capture">Se a transação foi capturada</param>
		/// <param name="total">Total do cancelamento</param>
		public Transaction cancellationRequest (
			Holder holder,
			Order order,
			PaymentMethod paymentMethod,
			String returnURL,
			Transaction.AuthorizationMethod authorize,
			bool capture,
			int total)
		{
			return cancellationRequest (transaction (holder, order, paymentMethod, returnURL, authorize, capture), total);
		}

		/// <summary>
		/// Envia uma requisição-cancelamento para o webservice Cielo para cancelar uma transação
		/// </summary>
		/// <returns>A transação com o respectivo status retornada pela Cielo</returns>
		/// <param name="transaction">A transação que será cancelada</param>
		public Transaction cancellationRequest (Transaction transaction)
		{
			return this.cancellationRequest (transaction, transaction.order.total);
		}

		/// <summary>
		/// Envia uma requisição-cancelamento para o webservice Cielo para cancelar uma transação
		/// </summary>
		/// <returns>A transação com o respectivo status retornada pela Cielo</returns>
		/// <param name="transaction">A transação que será cancelada</param>
		/// <param name="total">Total do cancelamento</param>
		public Transaction cancellationRequest (Transaction transaction, int total)
		{
			CancellationRequest request = CancellationRequest.create (transaction, total);
			return TransacaoElement.unserialize (transaction, sendHttpRequest (serialize (request)));
		}

        /// <summary>
        /// Envia uma requisição-cancelamento para o webservice Cielo para cancelar uma transação
        /// </summary>
        /// <param name="transaction">A transação que será cancelada</param>
        /// <param name="total">Total do cancelamento</param>
        /// <param name="tid">todo: describe tid parameter on cancellationRequest</param>
        /// <param name="merchant">todo: describe merchant parameter on cancellationRequest</param>
        /// <returns>A transação com o respectivo status retornada pela Cielo</returns>
        public Transaction cancellationRequest(string tid, int total, Merchant merchant = null)
        {
            CancellationRequest request = CancellationRequest.create(tid,merchant??this.merchant,total);
            return TransacaoElement.unserialize(null,sendHttpRequest(serialize(request)));
        }

		/// <summary>
		/// Envia uma requisição-captura para o webservice Cielo para capturar uma transação
		/// previamente autorizada
		/// </summary>
		/// <returns>A transação com o respectivo status retornada pela Cielo</returns>
		/// <param name="holder">Portador do cartão</param>
		/// <param name="order">Dados do pedido</param>
		/// <param name="paymentMethod">Método de pagamento</param>
		/// <param name="returnURL">URL de retorno</param>
		/// <param name="authorize">Método de autorização</param>
		/// <param name="capture">Se a transação foi capturada</param>
		/// <param name="total">Total da captura</param>
		public Transaction captureRequest (
			Holder holder,
			Order order,
			PaymentMethod paymentMethod,
			String returnURL,
			Transaction.AuthorizationMethod authorize,
			bool capture,
			int total)
		{
			return captureRequest (transaction (holder, order, paymentMethod, returnURL, authorize, capture), total);
		}

		/// <summary>
		/// Envia uma requisição-captura para o webservice Cielo para capturar uma transação
		/// previamente autorizada
		/// </summary>
		/// <returns>A transação com o respectivo status retornada pela Cielo</returns>
		/// <param name="transaction">A transação que deverá ser capturada</param>
		public Transaction captureRequest (Transaction transaction)
		{
			return this.captureRequest (transaction, transaction.order.total);
		}

		/// <summary>
		/// Envia uma requisição-captura para o webservice Cielo para capturar uma transação
		/// previamente autorizada
		/// </summary>
		/// <returns>A transação com o respectivo status retornada pela Cielo</returns>
		/// <param name="transaction">A transação que deverá ser capturada</param>
		/// <param name="total">O valor que deverá ser capturado</param>
		public Transaction captureRequest (Transaction transaction, int total)
		{
			CaptureRequest request = CaptureRequest.create (transaction, total);
			return TransacaoElement.unserialize (transaction, sendHttpRequest (serialize (request)));
		}

		/// <summary>
		/// Envia uma requisição-token para gerar um token para um cartão de crédito.
		/// </summary>
		/// <returns>O Token retornado pela Cielo</returns>
		/// <param name="transaction">A transação que contém os dados do portador</param>
		public Token tokenRequest (Transaction transaction)
		{
			TokenRequest request = TokenRequest.create (transaction);
			return RetornoTokenElement.unserialize (transaction, sendHttpRequest (serialize (request)));
		}

        /// <summary>
        /// Envia uma requisição-token para gerar um token para um cartão de crédito.
        /// </summary>
        /// <param name="transaction">A transação que contém os dados do portador</param>
        /// <param name="holder">todo: describe holder parameter on tokenRequest</param>
        /// <param name="merchant">todo: describe merchant parameter on tokenRequest</param>
        /// <returns>O Token retornado pela Cielo</returns>
        public Token tokenRequest(Holder holder, Merchant merchant = null)
        {
            TokenRequest request = TokenRequest.create(merchant??this.merchant, holder);
            return RetornoTokenElement.unserialize(sendHttpRequest(serialize(request)));
        }

		/// <summary>
		/// Envia uma requisição-transacao com os dados especificados
		/// </summary>
		/// <param name="holder">Detalhes do portador do cartão</param>
		/// <param name="order">Detalhes do pedido</param>
		/// <param name="paymentMethod">Forma de pagamento</param>
		/// <param name="returnURL">URL de retorno</param>
		/// <param name="authorize">Método de autorização</param>
		/// <param name="capture">Determina se a transação deverá ser capturada automaticamente</param>
		/// <returns>>Uma instância de Transaction com a resposta da requisição</returns>
		public Transaction transactionRequest (
			Holder holder,
			Order order,
			PaymentMethod paymentMethod,
			String returnURL,
			Transaction.AuthorizationMethod authorize,
			bool capture)
		{
			return transactionRequest (transaction (holder, order, paymentMethod, returnURL, authorize, capture));
		}

		/// <summary>
		/// Envia uma requisição-transacao com os dados especificados
		/// </summary>
		/// <param name="transaction">Detalhes da transação</param>
		/// <returns>>Uma instância de Transaction com a resposta da requisição</returns>
		public Transaction transactionRequest (Transaction transaction)
		{
			TransactionRequest request = TransactionRequest.create (transaction);
			return TransacaoElement.unserialize (transaction, sendHttpRequest (serialize (request)));
		}

        /// <summary>
        /// Envia uma requisição de consulta
        /// </summary>
        /// <param name="tid">TID da operação</param>        
        /// <returns>Uma instância de Transaction com a resposta da requisição</returns>
        public Transaction consultationRequest(String tid)
        {
            ConsultationRequest request = ConsultationRequest.create(tid, merchant);
            return TransacaoElement.unserialize(null, sendHttpRequest(serialize(request)));
        }
    }
}