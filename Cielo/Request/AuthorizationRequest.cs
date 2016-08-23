using System;
using System.ComponentModel;
using System.Xml.Serialization;
using CieloEcommerce.Request.Element;

namespace CieloEcommerce.Request
{
	[Serializable ()]
	[DesignerCategory ("code")]
	[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
	[XmlRoot ("requisicao-autorizacao-tid", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
	public partial class AuthorizationRequest :AbstractElement
	{
		[XmlElement ("tid")]
		public String tid { get; set; }

		[XmlElement ("dados-ec")]
		public DadosEcElement dadosEc { get; set; }

		public static AuthorizationRequest create (Transaction transaction)
		{
			var authorizationRequest = new AuthorizationRequest {
				id = Guid.NewGuid().ToString(),
				versao = Cielo.VERSION,
				tid = transaction.tid,
				dadosEc = new DadosEcElement {
					numero = transaction.merchant.id,
					chave = transaction.merchant.key
				}
			};

			return authorizationRequest;
		}
	}
}

