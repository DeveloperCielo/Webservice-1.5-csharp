using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
    [Serializable()]
    [XmlType(Namespace = "http://ecommerce.cbmp.com.br")]
    public class TokenElement : AbstractElement
    {
        [XmlType(Namespace = "http://ecommerce.cbmp.com.br")]
        public partial class DadosTokenElement
        {
            [XmlElement("codigo-token")]
            public String codigoToken { get; set; }

            public int status { get; set; }

            [XmlElement("numero-cartao-truncado")]
            public String numeroTruncado { get; set; }
        }

        [XmlElement("dados-token")]
        public DadosTokenElement dadosToken { get; set; }

        public Token ToToken()
        {
            Token token = new Token();
            token.code = dadosToken.codigoToken;
            token.status = dadosToken.status;
            token.number = dadosToken.numeroTruncado;

            return token;
        }
    }
}
