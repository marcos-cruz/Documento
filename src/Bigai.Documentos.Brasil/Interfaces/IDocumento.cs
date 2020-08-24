namespace Bigai.Documentos.Brasil.Interfaces
{
    /// <summary>
    /// <see cref="IDocumento"/> representa um contrato para manipulação de um documento.
    /// </summary>
    public interface IDocumento
    {
        /// <summary>
        /// Representa o número de um documento.
        /// </summary>
        string NumeroDocumento { get; }

        /// <summary>
        /// Sigla do estado emissor composta por 2 letras, segundo a norma ISO-3166.
        /// </summary>
        string EstadoEmissor { get; }
    }
}
