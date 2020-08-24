using Bigai.Documentos.Brasil.Helpers;
using Bigai.Documentos.Brasil.Interfaces;

namespace Bigai.Documentos.Brasil.Generics
{
    /// <summary>
    /// Esta classe é uma representação abstrata de um <see cref="Documento"/>.
    /// </summary>
    public abstract class Documento : ValueObject<Documento>, IDocumento
    {
        #region Constantes

        /// <summary>
        /// Tamanho máximo do número do documento.
        /// </summary>
        public static readonly int TamanhoNumeroDocumento = 20;
        
        /// <summary>
        /// Tamanho máximo do estado emissor.
        /// </summary>
        public static readonly int TamanhoEstadoEmissor = 2;

        #endregion

        #region Propriedades Publicas

        /// <summary>
        /// Representa o número de um documento.
        /// </summary>
        public string NumeroDocumento { get; protected set; }

        /// <summary>
        /// Sigla do estado emissor composta por 2 letras, segundo a norma ISO-3166.
        /// </summary>
        public string EstadoEmissor { get; protected set; }

        #endregion

        #region Construtor

        /// <summary>
        /// Retorna uma instância de <see cref="Documento"/>.
        /// </summary>
        protected Documento() : base() { }

        /// <summary>
        /// Retorna uma instância de <see cref="Documento"/>.
        /// </summary>
        /// <param name="numeroDocumento">Número do documento, com ou sem máscara de edição.</param>
        /// <param name="estadoEmissor">Sigla do estado emissor composta por 2 letras.</param>
        protected Documento(string numeroDocumento, string estadoEmissor)
        {
            NumeroDocumento = !string.IsNullOrEmpty(numeroDocumento) ? numeroDocumento.RemoverMascaraEdicao().Replace(" ", "").ToUpper() : "";
            EstadoEmissor = !string.IsNullOrEmpty(estadoEmissor) ? estadoEmissor.Trim().ToUpper() : "";
        }

        #endregion

        #region Consistência

        /// <summary>
        /// Determina se um documento está preenchido com informações válidas.
        /// </summary>
        /// <returns>Retorna <c>true</c> se o documento estiver válido, caso contrário <c>false</c>.</returns>
        public abstract bool EstaValido();

        #endregion

        #region Métodos Protegidos

        protected int ObterUltimoDigitoDeControleInformado()
        {
            int digitoControleInformado = -1;

            if (NumeroDocumento.Length > 0)
            {
                int posicao = NumeroDocumento.Length - 1;
                digitoControleInformado = int.Parse(NumeroDocumento[posicao].ToString());
            }

            return digitoControleInformado;
        }

        protected int[] ObterUltimosDoisDigitoDeControleInformado()
        {
            int[] digitoDeControleInformado = { -1, -1 };

            if (NumeroDocumento.Length > 1)
            {
                int posicao = NumeroDocumento.Length;
                digitoDeControleInformado[0] = int.Parse(NumeroDocumento[posicao - 2].ToString());
                digitoDeControleInformado[1] = int.Parse(NumeroDocumento[posicao - 1].ToString());
            }

            return digitoDeControleInformado;
        }

        #endregion
    }
}
