using System;
using System.ComponentModel;
using System.Xml.Serialization;
using CieloEcommerce.Request.Element;

namespace CieloEcommerce.Request
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://ecommerce.cbmp.com.br")]
    [XmlRoot("requisicao-consulta", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
    public partial class ConsultationRequest : AbstractElement
    {
        public String tid { get; set; }

        [XmlElement("dados-ec")]
        public DadosEcElement dadosEc { get; set; }

        public static ConsultationRequest create(String tid, Merchant merchant)
        {
            return new ConsultationRequest
            {
                id = Guid.NewGuid().ToString(),
                versao = Cielo.VERSION,
                tid = tid,
                dadosEc = new DadosEcElement
                {
                    numero = merchant.id,
                    chave = merchant.key
                }
            };
        }
    }
}
