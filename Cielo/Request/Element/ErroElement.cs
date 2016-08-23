using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
	[Serializable ()]
	[XmlRoot ("erro", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
	public partial class ErroElement :AbstractElement
	{
		public String codigo { get; set; }

		public String mensagem { get; set; }
		
	}
}

