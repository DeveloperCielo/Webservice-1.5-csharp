using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
	[Serializable ()]
	[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
	public partial class AutorizacaoElement :AbstractElement
	{
		public int codigo { get; set; }

		public String mensagem { get; set; }

		[XmlElement ("data-hora")]
		public String dataHora { get; set; }

		public int valor { get; set; }

		public string lr { get; set; }

		public string arp { get; set; }

		public int nsu { get; set; }

		public Authorization ToAuthorization ()
		{
			Authorization authorization = new Authorization ();

			authorization.code = codigo;
			authorization.message = mensagem;
			authorization.dateTime = dataHora;
			authorization.total = valor;
			authorization.lr = lr;
			authorization.arp = arp;
			authorization.nsu = nsu;

			return authorization;
		}
	}
}