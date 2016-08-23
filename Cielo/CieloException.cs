using System;

namespace CieloEcommerce
{
    /// <summary>
    /// Classe para captura do erro no XML
    /// </summary>
    public class CieloException : Exception
    {
        /// <summary>
        /// Código do erro
        /// </summary>
        public string Code { get; }
        /// <summary>
        /// Construtor
        /// </summary>
        public CieloException()
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="erroCode">Código do erro</param>
        /// <param name="innerException">Exceção</param>
        public CieloException(string message, string erroCode, Exception innerException) : base(message, innerException)
        {
            Code = erroCode;
        }
    }
}
