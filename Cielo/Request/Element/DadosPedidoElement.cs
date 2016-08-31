using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
	[Serializable ()]
	[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
	public partial class DadosPedidoElement :AbstractElement
	{
		public String numero { get; set; }

		public int valor { get; set; }

		public int moeda { get; set; }

		[XmlElement ("data-hora")]
		public String dataHora { get; set; }

		[XmlElement ("descricao", IsNullable = false)]
		public String descricao { get; set; }

		[XmlElement ("idioma", IsNullable = false)]
		public String idioma { get; set; }

		[XmlElement ("taxa-embarque", IsNullable = false)]
		public int taxaEmbarque { get; set; }

		[XmlElement ("soft-descriptor")]
		public String softDescriptor { get; set; }

		public Order ToOrder ()
		{
			Order order = new Order (numero, valor, dataHora, moeda);

			order.description = descricao;
			order.language = idioma;
			order.shipping = taxaEmbarque;
			order.softDescriptor = softDescriptor;

			return order;
		}
	}
}