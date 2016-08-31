using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
	[Serializable ()]
	[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
	public partial class DadosEcElement :AbstractElement
	{
		public String numero { get; set; }

		public String chave { get; set; }

		public Merchant ToMerchant ()
		{
			return new Merchant (numero, chave);
		}
	}
}