using System;
using System.ComponentModel;
using System.Xml.Serialization;
using CieloEcommerce.Request.Element;

namespace CieloEcommerce.Request
{
	[Serializable ()]
	[DesignerCategory ("code")]
	[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
	[XmlRoot ("requisicao-captura", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
	public partial class CaptureRequest :AbstractElement
	{
		[XmlElement ("tid")]
		public String tid { get; set; }

		[XmlElement ("dados-ec")]
		public DadosEcElement dadosEc { get; set; }

		public int valor { get; set; }

		public static CaptureRequest create (Transaction transaction)
		{
			return CaptureRequest.create (transaction, transaction.order.total);
		}

		public static CaptureRequest create (Transaction transaction, int total)
		{
			var cancellationRequest = new CaptureRequest {
				id = Guid.NewGuid().ToString(),
				versao = Cielo.VERSION,
				tid = transaction.tid,
				dadosEc = new DadosEcElement {
					numero = transaction.merchant.id,
					chave = transaction.merchant.key
				},
				valor = total
			};

			return cancellationRequest;
		}
	}
}

