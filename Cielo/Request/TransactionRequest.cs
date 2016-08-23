using System;
using System.Xml.Serialization;
using CieloEcommerce.Request.Element;

namespace CieloEcommerce.Request
{
	[Serializable ()]
	[XmlRoot ("requisicao-transacao", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
	public partial class TransactionRequest :AbstractElement
	{
		[XmlElement ("dados-ec")]
		public DadosEcElement dadosEc { get; set; }

		[XmlElement ("dados-portador")]
		public DadosPortadorElement dadosPortador { get; set; }

		[XmlElement ("dados-pedido")]
		public DadosPedidoElement dadosPedido { get; set; }

		[XmlElement ("forma-pagamento")]
		public FormaPagamentoElement formaPagamento { get; set; }

		[XmlElement ("url-retorno")]
		public String urlRetorno { get; set; }

		public int autorizar { get; set; }

		public String capturar { get; set; }

		[XmlElement ("campo-livre")]
		public String campoLivre { get; set; }

		public String bin { get; set; }

		[XmlElement ("gerar-token")]
		public String gerarToken { get; set; }

        public static TransactionRequest create (Transaction transaction)
        {
            var transactionRequest = new TransactionRequest {
                id = Guid.NewGuid().ToString(),
                versao = Cielo.VERSION,
                dadosEc = new DadosEcElement {
                    numero = transaction.merchant.id,
                    chave = transaction.merchant.key
                },
                dadosPortador = string.IsNullOrEmpty(transaction.holder.token) ?
                    new DadosPortadorElement {
                        numero = transaction.holder.number,
                        validade = transaction.holder.expiration,
                        nomePortador = transaction.holder.name,
                        codigoSeguranca = transaction.holder.cvv
                    } 
                    : new DadosPortadorElement {
                        token = transaction.holder.token
                    },
                dadosPedido = new DadosPedidoElement {
                    numero = transaction.order.number,
                    valor = transaction.order.total,
                    moeda = transaction.order.currency,
                    dataHora = transaction.order.dateTime,
                    descricao = transaction.order.description,
                    idioma = transaction.order.language,
                    taxaEmbarque = transaction.order.shipping,
                    softDescriptor = transaction.order.softDescriptor
                },
                formaPagamento = new FormaPagamentoElement {
                    bandeira = transaction.paymentMethod.issuer,
                    produto = transaction.paymentMethod.product,
                    parcelas = transaction.paymentMethod.installments
                },
                urlRetorno = transaction.returnURL,
                autorizar = (int)transaction.authorize,
                capturar = transaction.capture ? "true" : "false"
            };

            if (transaction.freeField != null) {
                transactionRequest.campoLivre = transaction.freeField;
            }

            if (transaction.bin != null) {
                transactionRequest.bin = transaction.bin;
            }

            if (transaction.generateToken) {
                transactionRequest.gerarToken = "true";
            }

            return transactionRequest;
        }
	}
}

