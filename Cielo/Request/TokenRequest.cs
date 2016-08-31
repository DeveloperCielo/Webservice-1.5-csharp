using System;
using System.ComponentModel;
using System.Xml.Serialization;
using CieloEcommerce.Request.Element;

namespace CieloEcommerce.Request
{
	[Serializable ()]
	[DesignerCategory ("code")]
	[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
	[XmlRoot ("requisicao-token", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
	public partial class TokenRequest :AbstractElement
	{
		[XmlElement ("dados-ec")]
		public DadosEcElement dadosEc { get; set; }

		[XmlElement ("dados-portador")]
		public DadosPortadorElement dadosPortador { get; set; }

		public static TokenRequest create (Transaction transaction)
		{
			var tokenRequest = new TokenRequest {
                id = Guid.NewGuid().ToString(),
				versao = Cielo.VERSION,
				dadosEc = new DadosEcElement {
					numero = transaction.merchant.id,
					chave = transaction.merchant.key
				},
				dadosPortador = new DadosPortadorElement {
					numero = transaction.holder.number,
					validade = transaction.holder.expiration,
					nomePortador = transaction.holder.name
				}
			};

			return tokenRequest;
		}

        public static TokenRequest create(Merchant merchant, Holder holder)
        {
            var tokenRequest = new TokenRequest
            {
                id = Guid.NewGuid().ToString(),
                versao = Cielo.VERSION,
                dadosEc = new DadosEcElement
                {
                    numero = merchant.id,
                    chave = merchant.key
                },
                dadosPortador = new DadosPortadorElement
                {
                    numero = holder.number,
                    validade = holder.expiration,
                    nomePortador = holder.name
                }
            };

            return tokenRequest;
        }
	}
}

