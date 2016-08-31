using System;
using System.Xml.Serialization;

namespace CieloEcommerce.Request.Element
{
	[Serializable ()]
	[XmlRoot ("retorno-token", Namespace = "http://ecommerce.cbmp.com.br", IsNullable = false)]
	public class RetornoTokenElement :AbstractElement
	{
		[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
		public partial class DadosTokenElement
		{
			[XmlElement ("codigo-token")]
			public String codigoToken { get; set; }

			public int status { get; set; }

			[XmlElement ("numero-cartao-truncado")]
			public String numeroTruncado { get; set; }
		}

		[XmlType (Namespace = "http://ecommerce.cbmp.com.br")]
		public partial class TokenElement
		{
			[XmlElement ("dados-token")]
			public DadosTokenElement dadosToken { get; set; }
		}

		public TokenElement token { get; set; }

		public static Token unserialize (Transaction transaction, String response)
		{
			RetornoTokenElement tokenElement = new RetornoTokenElement ();
			tokenElement = tokenElement.unserializeElement (tokenElement, response);

			Token token = new Token ();

			token.code = tokenElement.token.dadosToken.codigoToken;
			token.status = tokenElement.token.dadosToken.status;
			token.number = tokenElement.token.dadosToken.numeroTruncado;

			return token;
		}

        public static Token unserialize(String response)
        {
            RetornoTokenElement tokenElement = new RetornoTokenElement();
            tokenElement = tokenElement.unserializeElement(tokenElement, response);

            Token token = new Token();

            token.code = tokenElement.token.dadosToken.codigoToken;
            token.status = tokenElement.token.dadosToken.status;
            token.number = tokenElement.token.dadosToken.numeroTruncado;

            return token;
        }
	}
}