using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
    [Serializable()]
    [XmlRoot("transacao", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class TransacaoElement : AbstractElement
    {
        public String tid { get; set; }

        public String pan { get; set; }

        [XmlElement("dados-pedido")]
        public DadosPedidoElement dadosPedido { get; set; }

        [XmlElement("forma-pagamento")]
        public FormaPagamentoElement formaPagamento { get; set; }

        public String status;

        public AutenticacaoElement autenticacao { get; set; }

        public AutorizacaoElement autorizacao { get; set; }

        [XmlElement("url-autenticacao")]
        public String urlAutenticacao;

        public TokenElement token { get; set; }


        public static Transaction unserialize(Transaction transaction, String response)
        {
            TransacaoElement transacao = new TransacaoElement();
            transacao = transacao.unserializeElement(transacao, response);

            Console.Write(response);

            if (transaction == null)
                transaction = new Transaction();

            transaction.tid = transacao.tid;
            transaction.pan = transacao.pan;
            transaction.order = transacao.dadosPedido.ToOrder();
            transaction.paymentMethod = transacao.formaPagamento.ToPaymentMethod();

            if (transacao.autenticacao != null)
            {
                transaction.authentication = transacao.autenticacao.ToAuthentication();
            }

            if (transacao.autorizacao != null)
            {
                transaction.authorization = transacao.autorizacao.ToAuthorization();
            }

            if (transacao.token != null)
            {
                transaction.token = transacao.token.ToToken();
            }

            int status = 0;
            if (int.TryParse(transacao.status, out status))
            {
                transaction.status = status;
            }            

            transaction.authenticationUrl = transacao.urlAutenticacao;

            return transaction;
        }
    }
}