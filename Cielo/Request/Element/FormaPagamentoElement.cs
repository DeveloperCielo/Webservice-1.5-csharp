using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
	[Serializable ()]
	[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
	public partial class FormaPagamentoElement
	{
		public String bandeira { get; set; }

		public String produto { get; set; }

		public int parcelas { get; set; }

		public PaymentMethod ToPaymentMethod ()
		{
			PaymentMethod paymentMethod = new PaymentMethod (bandeira);

			paymentMethod.product = produto;
			paymentMethod.installments = parcelas;

			return paymentMethod;
		}
	}
}